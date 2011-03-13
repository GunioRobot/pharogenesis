mouseDown: evt
	"The mouse went down on the receiver; take appropriate action"

	| aPoint |
	"Note: evt is in local coordinates, so bounds is better than boundsInWorld"

	aPoint _ evt cursorPoint.
	nArrowTicks _ 0.
	upArrow ifNotNil:
		[(upArrow bounds containsPoint: aPoint) ifTrue: [^ self mouseStillDown: evt].
		(downArrow bounds containsPoint: aPoint) ifTrue: [^ self mouseStillDown: evt].
		"next line maybe outside this block & below it"
		operatorOrExpression ifNotNil: [^ self presentOperatorAlternatives: evt]].
	
	suffixArrow ifNotNil:
		[(suffixArrow bounds containsPoint: aPoint)
			 ifTrue: [self showSuffixChoices.  ^ self]].
	retractArrow ifNotNil:
		[(retractArrow bounds containsPoint: aPoint)
			 ifTrue: [self deleteLastTwoTiles.  ^ self]].
	^ super mouseDown: evt