withSize: aRectangle

	| offset scale p1 p2 p3 |
	area := aRectangle.
	"Construct a triangle containing area"
	offset := area origin.
	scale := area extent.
	p1 := (-1@-1) * scale + offset.
	p2 := (2@-1) * scale + offset.
	p3 := (0.5@3) * scale + offset.
	self p1: p1 p2: p2 p3: p3.