text: text bounds: boundsRect font: fontOrNil color: color
	"Draw the given string in the given font and color clipped to the given rectangle. If the font is nil, the default font is used."
	"(innerClipRect intersects: (transform transformBoundsRect: boundsRect)) ifFalse: [ ^self ]."
		"clip rectangles seem to be all screwed up...."
	text isAllSeparators ifTrue: [ ^self ].   "is this correct??  it sure does speed things up!"
	self drawCommand: [ :executor |
		executor text: text bounds: boundsRect font: fontOrNil color: color ]