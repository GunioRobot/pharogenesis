handlesMouseDown: evt
	| aPoint |
	aPoint _ evt cursorPoint.
	upArrow ifNotNil: [((upArrow boundsInWorld containsPoint: aPoint) or: [downArrow boundsInWorld containsPoint: aPoint])
		ifTrue: [^ true]].
	suffixArrow ifNotNil: [(suffixArrow boundsInWorld containsPoint: aPoint)
		ifTrue: [^ true]].
	^ super handlesMouseDown: evt