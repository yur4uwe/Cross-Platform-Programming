; mpr.inc
; файл ?з ?менами функц?й ?з mpr.dll
;

ifdef _TASM_
	includelib import32.lib
	;  ?мена  функц?й, як? використан?
		extrn	WNetGetUserA:near
		extrn	WNetOpenEnumA:near
		extrn	WNetEnumResourceA:near
		extrn	WNetCloseEnum:near
	; 
	WNetGetUser	equ	WNetGetUserA
	WNetOpenEnum	equ	WNetOpenEnumA
	WNetEnumResource equ	WNetEnumResourceA
else
	includelib mpr.lib
	; справжн? ?мена  функц?й, як? використан?
		extrn	__imp__WNetGetUserA@12:dword
		extrn	__imp__WNetOpenEnumA@20:dword
		extrn	__imp__WNetEnumResourceA@16:dword
		extrn	__imp__WNetCloseEnum@4:dword
	; присвоєння для полегшення читабельност? коду
	WNetGetUser	equ	__imp__WNetGetUserA@12
	WNetOpenEnum	equ	__imp__WNetOpenEnumA@20
	WNetEnumResource equ	__imp__WNetEnumResourceA@16
	WNetCloseEnum	equ	__imp__WNetCloseEnum@4
endif


