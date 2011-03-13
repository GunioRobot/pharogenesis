selection: anInteger
	selection _ anInteger.
	self changed: #selection.
	monitor listChanged.
