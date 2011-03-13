mouseMove: evt
	super mouseMove: evt.
	(editView scrollSelectionIntoView: evt) ifTrue: [evt hand updateMouseDownTransform]