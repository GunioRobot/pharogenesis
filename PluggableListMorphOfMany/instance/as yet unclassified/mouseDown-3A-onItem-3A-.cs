mouseDown: event onItem: aMorph
	| index oldIndex oldVal |
	event yellowButtonPressed ifTrue: [^ self yellowButtonActivity: event shiftPressed].
	model okToChange ifFalse: [^ self].  "No change if model is locked"

	index _ scroller submorphs indexOf: aMorph.
	index = 0 ifTrue: [^ self  "minimize chance of selecting with a pane border drag"].

	"Set meaning for subsequent dragging of selection"
	dragOnOrOff _ (model listSelectionAt: index) not.
	oldIndex _ self getCurrentSelectionIndex.
	oldIndex ~= 0 ifTrue: [oldVal _ model listSelectionAt: oldIndex].

	"Set or clear new primary selection (listIndex)"
	dragOnOrOff
		ifTrue: [self setSelectedMorph: aMorph]
		ifFalse: [self setSelectedMorph: nil].

	"Need to restore the old one, due to how model works, and set new one."
	oldIndex ~= 0 ifTrue: [model listSelectionAt: oldIndex put: oldVal].
	model listSelectionAt: index put: dragOnOrOff.
	event hand releaseMouseFocus: aMorph.
	aMorph changed