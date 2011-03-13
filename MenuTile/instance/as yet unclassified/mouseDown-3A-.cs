mouseDown: evt
	| aPoint aMenu reply |
	aPoint _ evt cursorPoint.
	nArrowTicks _ 0.
	upArrow ifNotNil:
		[(upArrow boundsInWorld containsPoint: aPoint) ifTrue: [^ self].
		(downArrow boundsInWorld containsPoint: aPoint) ifTrue: [^ self]].
	aMenu _ SelectionMenu selections: ((self ownerThatIsA: PhraseTileMorph) associatedPlayer costume allMenuWordings).
	reply _ aMenu startUp.
	reply ifNotNil: [self literal: reply; layoutChanged]