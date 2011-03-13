mouseUp: evt
	super mouseUp: evt.
	self stopSteppingSelector: #autoScrollView:.
	"editView scrollSelectionIntoView: evt."
	editView selectionInterval: editor selectionInterval.
	self setCompositionWindow.
