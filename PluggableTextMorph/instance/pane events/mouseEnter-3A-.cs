mouseEnter: event
	super mouseEnter: event.
	selectionInterval ifNotNil:
		[textMorph handleEdit: [textMorph editor selectInterval: selectionInterval]].
	event hand newKeyboardFocus: textMorph