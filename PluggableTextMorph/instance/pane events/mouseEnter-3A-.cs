mouseEnter: event
	super mouseEnter: event.
	selectionInterval ifNotNil:
		[textMorph handleEdit: [textMorph editor selectInterval: selectionInterval.
			textMorph editor setEmphasisHere]].
	event hand newKeyboardFocus: textMorph