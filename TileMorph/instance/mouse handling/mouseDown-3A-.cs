mouseDown: evt
	| aPoint |
	aPoint _ evt cursorPoint.
	nArrowTicks _ 0.
	upArrow ifNotNil:
		[(upArrow boundsInWorld containsPoint: aPoint) ifTrue: [^ self].
		(downArrow boundsInWorld containsPoint: aPoint) ifTrue: [^ self]].
	suffixArrow ifNotNil:
		[(suffixArrow boundsInWorld containsPoint: aPoint)
			 ifTrue: [self showSuffixChoices.  ^ self]].
	^ super mouseDown: evt