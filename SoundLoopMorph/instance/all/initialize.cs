initialize
	super initialize.
	borderWidth _ 1.
	bounds _ 0@0 corner: (128@128) + (borderWidth*2).
	color _ Color lightBlue.
	controlIndex _ 0.
	self addCursorMorph