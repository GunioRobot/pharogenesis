mouseDown: event
	| oldIndex oldVal row |
	event yellowButtonPressed ifTrue: [^ self yellowButtonActivity: event shiftPressed].
	row := self rowAtLocation: event position.

	row = 0 ifTrue: [^super mouseDown: event].

	model okToChange ifFalse: [^ self].  "No change if model is locked"

	"Set meaning for subsequent dragging of selection"
	dragOnOrOff _ (self listSelectionAt: row) not.
	oldIndex _ self getCurrentSelectionIndex.
	oldIndex ~= 0 ifTrue: [oldVal _ self listSelectionAt: oldIndex].

	"Set or clear new primary selection (listIndex)"
	dragOnOrOff
		ifTrue: [self changeModelSelection: row]
		ifFalse: [self changeModelSelection: 0].

	"Need to restore the old one, due to how model works, and set new one."
	oldIndex ~= 0 ifTrue: [self listSelectionAt: oldIndex put: oldVal].
	self listSelectionAt: row put: dragOnOrOff.
	"event hand releaseMouseFocus: aMorph."
	"aMorph changed"