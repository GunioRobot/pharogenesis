strokeMode
	self world prepareToPaint: false.
	self clearStroke.
	self mode: #stroke.
	Cursor crossHair beCursor.
	self removeHalo.