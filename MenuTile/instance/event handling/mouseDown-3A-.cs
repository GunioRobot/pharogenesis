mouseDown: evt
	| aPoint aMenu reply |
	aPoint _ evt cursorPoint.
	nArrowTicks _ 0.
	((upArrow bounds containsPoint: aPoint) or: [downArrow bounds containsPoint: aPoint]) ifTrue: [^ self mouseStillDown: evt].
	aMenu _ SelectionMenu selections: (((self ownerThatIsA: PhraseTileMorph) associatedPlayer costume allMenuWordings) copyWithout: '').
	reply _ aMenu startUp.
	reply ifNotNil: [self literal: reply; layoutChanged]