selectTask: aTask
	"Make the given task active and update the buttons."
	
	self tasks do: [:t | t state: #restored].
	aTask state: #active.
	self updateButtonsAndPreview