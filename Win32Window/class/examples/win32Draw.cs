win32Draw "Win32Window win32Draw"
	"Draw a bunch of lines using the Windows API"
	| hWnd hDC pt |
	hWnd _ Win32Window getFocus.
	hDC _ hWnd getDC.
	hDC moveTo: (hWnd screenToClient: Win32Point getCursorPos).
	[Sensor anyButtonPressed] whileFalse:[
		pt _ Win32Point getCursorPos.
		hWnd screenToClient: pt.
		hDC lineTo: pt.
	].
	hWnd releaseDC: hDC.
	Display forceToScreen.