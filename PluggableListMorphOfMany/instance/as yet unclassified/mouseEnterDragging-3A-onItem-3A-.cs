mouseEnterDragging: event onItem: aMorph
	| index oldIndex oldVal |
	dragOnOrOff ifNil: [^ self "spurious drag did not start with mouseDown"].
	event yellowButtonPressed ifTrue: [^ self yellowButtonActivity: event shiftPressed].
	model okToChange ifFalse: [^ self].  "No change if model is locked"

	oldIndex _ self getCurrentSelectionIndex.
	oldIndex ~= 0 ifTrue: [oldVal _ model listSelectionAt: oldIndex].

	index _ scroller submorphs indexOf: aMorph.
	dragOnOrOff ifTrue: [self setSelectedMorph: aMorph].
	oldIndex ~= 0 ifTrue: [model listSelectionAt: oldIndex put: oldVal].

	"Extend the selection with the current state of dragOnOrOff"
	model listSelectionAt: index put: dragOnOrOff.
	aMorph changed