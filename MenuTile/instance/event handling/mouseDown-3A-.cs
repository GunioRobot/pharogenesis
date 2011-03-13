mouseDown: evt
	| aPoint aMenu reply |
	aPoint := evt cursorPoint.
	nArrowTicks := 0.
	((upArrow bounds containsPoint: aPoint) or: [downArrow bounds containsPoint: aPoint]) ifTrue: [^ self mouseStillDown: evt].
	aMenu := SelectionMenu selections: (((self ownerThatIsA: PhraseTileMorph) associatedPlayer costume allMenuWordings) copyWithout: '').
	reply := aMenu startUp.
	reply ifNotNil: [self literal: reply; layoutChanged]