sideNearestTo: aPoint
	| distToLeft itsX distToRight distToTop itsY distToBottom horizontalChoice horizontalDistance verticalChoice verticalDistance |
	distToLeft _ (self left - (itsX _ aPoint x)) abs.
	distToRight _ (self right - itsX) abs.
	distToTop _ (self top - (itsY _ aPoint y)) abs.
	distToBottom _ (self bottom - itsY) abs.
	distToLeft < distToRight 
		ifTrue: 
			[horizontalChoice _ #left.  
			horizontalDistance _ distToLeft]
		ifFalse:
			[horizontalChoice _ #right.
			horizontalDistance _ distToRight].
	distToTop < distToBottom
		ifTrue: 
			[verticalChoice _ #top.  
			verticalDistance _ distToTop]
		ifFalse:
			[verticalChoice _ #bottom.
			verticalDistance _ distToBottom].
	horizontalDistance < verticalDistance
		ifTrue:
			[^ horizontalChoice]
		ifFalse:
			[^ verticalChoice]