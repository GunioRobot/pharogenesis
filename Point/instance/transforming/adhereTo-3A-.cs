adhereTo: aRectangle
	"If the receiver lies outside aRectangle, return the nearest point on the boundary of the rectangle, otherwise return self."

	(aRectangle containsPoint: self)
	ifTrue: [^ self]
	ifFalse: [^ (x min: (aRectangle corner x) max: (aRectangle origin x))
			@ (y min: (aRectangle corner y) max: (aRectangle origin y))]