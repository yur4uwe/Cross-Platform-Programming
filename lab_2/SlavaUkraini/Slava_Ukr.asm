; winhello.asm
; Графiчний win32-додаток
; Виводить вsкно типу mesagebox з текстом "Usim Pryvit!"
;
; Компsлювання MASM
;  ml /c /coff /Cp W_pryvit.asm
;  link W_pryvit.obj /subsystem:windows

;
include def32.inc
include kernel32.inc
include user32.inc

	.386
	.model flat
	.const
; заголовок в?кна
hello_title	db 'XIO first win32 GUI proga',0
; сообщение
hello_message	db 'Slava Ukraini!',0
	.code
_start:
	push	MB_ICONINFORMATION	; стиль вiкна
	push	offset hello_title	; адреса рядка iз заголовком
	push	offset hello_message	; адреса рядка iз повiдомленням
	push	0			; iдентифiкатор предка
	call	MessageBox

	push	0		; код виходу 
	call	ExitProcess	; завершення програми
end	_start
