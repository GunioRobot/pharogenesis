computeBoundingBox
	| aRectangle aPoint |
	aRectangle _ center - radius + form offset extent: form extent + (radius * 2) asPoint.
	aPoint _ center + form extent.
	quadrant = 1 ifTrue: [aRectangle left: center x; bottom: aPoint y].
	quadrant = 2 ifTrue: [aRectangle right: aPoint x; bottom: aPoint y].
	quadrant = 3 ifTrue: [aRectangle right: aPoint x; top: center y].
	quadrant = 4 ifTrue: [aRectangle left: center x; top: center y].
	^aRectangle