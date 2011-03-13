cursorPoint: aPoint 
	"Set the current cursor position to be aPoint.  But don't actually do it,
	since Macintosh cursors don't relocate too well."

	"self primCursorLocPut: aPoint.
	x _ aPoint x.
	y _ aPoint y"