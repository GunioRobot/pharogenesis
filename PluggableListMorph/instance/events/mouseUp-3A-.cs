mouseUp: event
	"The mouse came up within the list; take appropriate action"

	| row |
	row _ self rowAtLocation: event position.
	"aMorph ifNotNil: [aMorph highlightForMouseDown: false]."
	model okToChange ifFalse:
		[^ self].
	(autoDeselect == false and: [row == 0]) ifTrue: [^ self].  "work-around the no-mans-land bug"
	"No change if model is locked"
	((autoDeselect == nil or: [autoDeselect]) and: [row == self selectionIndex])
		ifTrue: [self changeModelSelection: 0]
		ifFalse: [self changeModelSelection: row].
	Cursor normal show.
