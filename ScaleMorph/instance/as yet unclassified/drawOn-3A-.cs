drawOn: aCanvas
	| scale x1 y1 y2 x y3 even yy |
	super drawOn: aCanvas.
	scale _ (self innerBounds width-1) / (stop-start) asFloat.
	x1 _ self innerBounds left.
	y1 _ self innerBounds bottom - 1.
	y2 _ y1 - minorTickLength.
	start to: stop by: minorTick do:
		[:v | x _ x1 + (scale*v).
		aCanvas line: x@y1 to: x@y2 width: 1 color: Color black].
	x1 _ self innerBounds left.
	y2 _ y1 - majorTickLength.
	y3 _ y1 - (minorTickLength+majorTickLength//2).
	even _ true.
	start to: stop by: majorTick/2.0 do:
		[:v | x _ x1 + (scale*v).
		yy _ even ifTrue: [y2] ifFalse: [y3].
		aCanvas line: x@y1 to: x@yy width: 1 color: Color black.
		even _ even not].
