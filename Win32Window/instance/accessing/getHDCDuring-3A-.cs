getHDCDuring: aBlock
	"Provide a Win32 HDC during the execution of aBlock"
	| hDC |
	hDC _ self getDC.
	[aBlock value: hDC] ensure:[self releaseDC: hDC].