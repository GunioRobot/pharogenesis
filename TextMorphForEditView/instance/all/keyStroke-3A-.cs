keyStroke: evt
	self editor model: editView model.  "For evaluateSelection"
	super keyStroke: evt.
	editView scrollSelectionIntoView