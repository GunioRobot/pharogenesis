mouseDown: evt
	| aPoint |
	aPoint _ evt cursorPoint.
	nArrowTicks _ 0.
	upArrow ifNotNil:
		[(upArrow containsPoint: aPoint) ifTrue: [^ self].
		(downArrow containsPoint: aPoint) ifTrue: [^ self]].
	suffixArrow ifNotNil:
		[(suffixArrow containsPoint: aPoint)
			 ifTrue: [self showSuffixChoices.  ^ self]].
	^ super mouseDown: evt