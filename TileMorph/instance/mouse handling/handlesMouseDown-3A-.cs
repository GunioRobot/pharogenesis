handlesMouseDown: evt
	| aPoint |
	aPoint _ evt cursorPoint.
	upArrow ifNotNil: [((upArrow containsPoint: aPoint) or: [downArrow containsPoint: aPoint])
		ifTrue: [^ true]].
	suffixArrow ifNotNil: [(suffixArrow containsPoint: aPoint)
		ifTrue: [^ true]].
	^ super handlesMouseDown: evt