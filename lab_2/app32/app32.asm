include def32.inc
include user32.inc
include kernel32.inc

    .386
    .model flat
.const
    c_w_name         db  '32-bit application',0
    btn_text         db  'Press me',0
    btn_class        db  'button',0
    fail_msg         db  'DialogBoxParam failed!',0
    BUTTON_ID        equ 1001
    BS_PUSHBUTTON    equ 0

    IDD_CONFIRM_EXIT equ 700
    ID_OK            equ 701
    ID_NO            equ 702
.data
             wc   WNDCLASSEX <SIZE WNDCLASSEX, CS_HREDRAW or CS_VREDRAW, offset win_proc, 0, 0, 0, 0, 0, COLOR_WINDOW+1, 0, offset c_w_name, 0>
             msg_ MSG <>
    hWndMain dd   0

.code
    _start:       
                  xor   ebx, ebx
                  call  GetModuleHandle
                  mov   wc.hInstance, eax

                  push  IDI_APPLICATION
                  push  ebx
                  call  LoadIcon
                  mov   wc.hIcon, eax
                  mov   wc.hIconSm, eax

                  push  IDC_ARROW
                  push  ebx
                  call  LoadCursor
                  mov   wc.hCursor, eax

                  push  offset wc
                  call  RegisterClassEx

                  push  ebx                                        ; lpParam
                  push  wc.hInstance                               ; hInstance
                  push  ebx                                        ; hMenu
                  push  ebx                                        ; hWndParent
                  push  200                                        ; nHeight
                  push  300                                        ; nWidth
                  push  CW_USEDEFAULT                              ; Y
                  push  CW_USEDEFAULT                              ; X
                  push  WS_OVERLAPPEDWINDOW                        ; dwStyle
                  push  offset c_w_name                            ; lpWindowName
                  push  offset c_w_name                            ; lpClassName
                  push  WS_EX_CLIENTEDGE                           ; dwExStyle
                  call  CreateWindowEx

                  mov   esi, eax                                   ; save window handle
                  mov   hWndMain, eax

                  push  SW_SHOWNORMAL
                  push  esi
                  call  ShowWindow
                  call  UpdateWindow

    ; Create the button
                  push  ebx                                        ; lpParam
                  push  wc.hInstance                               ; hInstance
                  push  BUTTON_ID                                  ; hMenu (control ID)
                  push  esi                                        ; hWndParent
                  push  30                                         ; nHeight
                  push  80                                         ; nWidth
                  push  80                                         ; Y
                  push  100                                        ; X
                  push  WS_CHILD or WS_VISIBLE or BS_PUSHBUTTON    ; dwStyle
                  push  offset btn_text                            ; lpWindowName
                  push  offset btn_class                           ; lpClassName ("button" class is registered by default)
                  push  0                                          ; dwExStyle
                  call  CreateWindowEx

                  mov   edi, offset msg_
    msg_loop:     
                  push  ebx
                  push  ebx
                  push  ebx
                  push  edi
                  call  GetMessage
                  test  eax, eax
                  jz    exit_msg_loop
                  push  edi
                  call  TranslateMessage
                  push  edi
                  call  DispatchMessage
                  jmp   short msg_loop

    exit_msg_loop:
                  push  msg_.wParam
                  call  ExitProcess

win_proc proc near
                  push  ebp
                  mov   ebp, esp
    wp_hWnd       equ   dword ptr [ebp+08h]
    wp_uMsg       equ   dword ptr [ebp+0Ch]
    wp_wParam     equ   dword ptr [ebp+10h]
    wp_lParam     equ   dword ptr [ebp+14h]
                  cmp   wp_uMsg, WM_COMMAND
                  jne   check_destroy
                  mov   eax, wp_wParam
                  and   eax, 0FFFFh
                  cmp   eax, BUTTON_ID
                  jne   def_proc

    ; Show the dialog
                  push  0                                          ; lParam
                  push  offset confirm_exit                        ; Dialog proc
                  push  wp_hWnd                                    ; Owner window
                  push  IDD_CONFIRM_EXIT                           ; Dialog resource ID (as integer)
                  push  wc.hInstance                               ; hInstance
                  call  DialogBoxParam
                  
                  cmp   eax, -1

                  jne   dialog_ok
    ; Dialog failed, show error
                  push  0
                  push  offset c_w_name
                  push  offset fail_msg
                  push  wp_hWnd
                  call  MessageBox
                  jmp   def_proc
    dialog_ok:    

                  cmp   eax, ID_OK
                  jne   def_proc
                  push  0
                  call  PostQuitMessage
                  jmp   def_proc
    check_destroy:
                  cmp   wp_uMsg, WM_DESTROY
                  jne   def_proc
                  push  0
                  call  PostQuitMessage
    def_proc:     
                  push  wp_lParam
                  push  wp_wParam
                  push  wp_uMsg
                  push  wp_hWnd
                  call  DefWindowProc
                  leave
                  ret   16
win_proc endp

confirm_exit proc near
                  push  ebp
                  mov   ebp, esp
                  mov   eax, [ebp+0Ch]                             ; uMsg
                  cmp   eax, WM_COMMAND
                  jne   not_command
                  mov   eax, [ebp+10h]                             ; wParam
                  cmp   eax, ID_OK
                  je    ok_pressed
                  cmp   eax, ID_NO
                  je    no_pressed
    not_command:  
                  xor   eax, eax
                  leave
                  ret   16

    ok_pressed:   
                  push  ID_OK
                  push  [ebp+8]                                    ; hDlg
                  call  EndDialog
                  xor   eax, eax
                  leave
                  ret   16

    no_pressed:   
                  push  ID_NO
                  push  [ebp+8]                                    ; hDlg
                  call  EndDialog
                  xor   eax, eax
                  leave
                  ret   16
confirm_exit endp

                 

    end _start