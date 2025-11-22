; This program can only be ran in Visual Studion as it requires 
; a linker that supports Windows API calls.

.data
    welcomeMsg db 'Welcome to the Number Guessing Game!', 13, 10
               db 'I''m thinking of a number between 1 and 100...', 13, 10, 0
    promptMsg db 'Enter your guess: ', 0
    tooHighMsg db 'Too high! Try again.', 13, 10, 0
    tooLowMsg db 'Too low! Try again.', 13, 10, 0
    correctMsg db 'Congratulations! You guessed it in ', 0
    attemptsMsg db ' attempts!', 13, 10, 0
    newlineMsg db 13, 10, 0
    
    inputBuffer db 10 dup(?)        
    secretNumber dq ?               
    userGuess dq ?                  
    attemptCount dq 1
    bytesRead dq ?
    
    ; Buffer for number conversion
    tempStr db 20 dup(?)

.code
    ; External Windows API functions
    extrn ExitProcess: proc
    extrn GetStdHandle: proc
    extrn WriteConsoleA: proc
    extrn ReadConsoleA: proc
    extrn GetTickCount: proc

main proc
    sub rsp, 48h
    
    ; Display welcome message
    lea rcx, welcomeMsg
    call DisplayString
    
    call GenerateRandomNumber
    
GameLoop:
    lea rcx, promptMsg
    call DisplayString
    
    call GetUserInput
    
    ; Convert input to number
    call ConvertStringToNumber
    
    mov rax, userGuess
    cmp rax, secretNumber
    je GuessedCorrect
    jl GuessedTooLow
    jg GuessedTooHigh
    
GuessedTooHigh:
    lea rcx, tooHighMsg
    jmp PrintGuessMsg
    
GuessedTooLow:
    lea rcx, tooLowMsg

PrintGuessMsg:
    call DisplayString
    inc attemptCount
    jmp GameLoop
    
GuessedCorrect:
    lea rcx, correctMsg
    call DisplayString
    
    mov rax, attemptCount
    call ConvertNumberToString
    lea rcx, tempStr
    call DisplayString
    
    lea rcx, attemptsMsg
    call DisplayString
    
    mov rcx, 0
    call ExitProcess
    
    add rsp, 48h
    ret
main endp

; Display string pointed to by RCX
DisplayString proc
    sub rsp, 48h
    mov r15, rcx                    ; Save string address
    
    mov rcx, -11                    ; STD_OUTPUT_HANDLE
    call GetStdHandle
    mov r14, rax                    ; Save handle
    
    mov rcx, r15
    call StrLen
    mov r13, rax                    ; Save length
    
    ; Write to console
    mov rcx, r14                    ; Console handle
    mov rdx, r15                    ; String address
    mov r8, r13                     ; String length
    lea r9, bytesRead               ; Bytes written
    mov qword ptr [rsp + 20h], 0    ; Reserved stack space
    call WriteConsoleA
    
    add rsp, 48h
    ret
DisplayString endp

; Calculate string length (RCX - string address, returns length in RAX)
StrLen proc
    mov rax, 0
StrLenLoop:
    cmp byte ptr [rcx + rax], 0
    je StrLenDone
    inc rax
    jmp StrLenLoop
StrLenDone:
    ret
StrLen endp

; Generate random number 1-100
GenerateRandomNumber proc
    sub rsp, 28h
    
    ; Use tick count as seed
    call GetTickCount

    xor rdx, rdx
    mov rcx, 100                    ; Divide by 100
    div rcx                         ; RAX = quotient, RDX = remainder
    inc rdx                         ; Make it 1-100 instead of 0-99
    mov secretNumber, rdx
    
    add rsp, 28h
    ret
GenerateRandomNumber endp

; Get user input
GetUserInput proc
    sub rsp, 48h
    
    ; Get stdin handle
    mov rcx, -10                    ; STD_INPUT_HANDLE
    call GetStdHandle
    mov r14, rax                    ; Save handle
    
    ; Read from console
    mov rcx, r14                    ; Console handle
    lea rdx, inputBuffer            ; Input buffer
    mov r8, 9                       ; Max chars to read
    lea r9, bytesRead               ; Bytes read
    mov qword ptr [rsp + 20h], 0   ; Reserved
    call ReadConsoleA
    
    add rsp, 48h
    ret
GetUserInput endp

; Convert string in inputBuffer to number in userGuess
ConvertStringToNumber proc
    lea rsi, inputBuffer            ; Source string
    xor rax, rax                    ; Clear result register
    mov rcx, 10
    
ConvertLoop:
    movzx rdx, byte ptr [rsi]       ; Get next character (zero-extend to 64-bit)
    
    ; Skip special characters
    cmp dl, ' '                     ; Space
    je SkipChar
    cmp dl, 13                      ; Carriage return
    je SkipChar
    cmp dl, 10                      ; Line feed
    je SkipChar
    cmp dl, 9                       ; Tab
    je SkipChar
    
    ; Check if end of string
    cmp dl, 0
    je ConvertDone

    ; Check if digit ( ord('0') <= dl <= ord('9') )
    cmp dl, '0'
    jl ConvertDone
    cmp dl, '9'
    jg ConvertDone
    
    sub dl, '0'                     ; Convert ASCII to number
    imul rax, rcx                   ; RAX = RAX * 10 (using imul for clarity)
    add rax, rdx                    ; Add new digit
    inc rsi                         ; Move to next character
    jmp ConvertLoop
    
SkipChar:
    inc rsi                         ; Skip this character
    jmp ConvertLoop
    
ConvertDone:
    mov userGuess, rax              ; Store result in userGuess
    ret
ConvertStringToNumber endp

; Convert number in RAX to string in tempStr
ConvertNumberToString proc
    lea rdi, tempStr
    add rdi, 19                     ; Point to end of buffer
    mov byte ptr [rdi], 0           ; Null terminator
    dec rdi
    
    mov rcx, 10
    
ConvertNumLoop:
    mov rdx, 0                      ; Clear high part
    div rcx
    add dl, '0'                     ; Convert remainder to ASCII
    mov [rdi], dl                   ; Store digit
    dec rdi                         ; Previous position
    test rax, rax                   ; Check if quotient is 0
    jnz ConvertNumLoop
    
    ; Move string to beginning of buffer
    inc rdi                         ; Point to first digit
    lea rsi, [rdi]                  ; Source
    lea rdi, tempStr                ; Destination
    
CopyLoop:
    mov al, [rsi]
    mov [rdi], al
    test al, al                     ; Check for null terminator
    jz CopyDone
    inc rsi
    inc rdi
    jmp CopyLoop
    
CopyDone:
    ret
ConvertNumberToString endp

end