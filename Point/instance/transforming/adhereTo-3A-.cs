adhereTo: aRectangle
	"If the receiver lies outside aRectangle, it is mapped to the nearest point on the boundary of the rectangle"

(aRectangle containsPoint: self)
	ifFalse: [x _ x max: (aRectangle origin x).
			x _ x min: (aRectangle corner x).
			y _ y max: (aRectangle origin y).
			y _ y min: (aRectangle corner y)]
"Redo this more efficiently"
				