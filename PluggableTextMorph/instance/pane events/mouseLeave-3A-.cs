mouseLeave: event

	textMorph ifNotNil: [selectionInterval _ textMorph editor selectionInterval].
	super mouseLeave: event.
	event hand newKeyboardFocus: nil.
