selection: anInteger
	selection _ anInteger.
	self signalSelectionChanged.
	self changed: #selection.
