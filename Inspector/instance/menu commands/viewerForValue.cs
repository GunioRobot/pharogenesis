viewerForValue
	"Open up a viewer on the value of the receiver's current selection"

	| objectToRepresent |
	objectToRepresent _ self selectionIndex == 0 ifTrue: [object] ifFalse: [self selection].
	objectToRepresent beViewed
	