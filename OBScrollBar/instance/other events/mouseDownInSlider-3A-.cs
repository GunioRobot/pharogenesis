mouseDownInSlider: event
	interval = 1.0 ifTrue:
		["make the entire scrollable area visible if a full scrollbar is clicked on"
		self setValue: 0.
		self model hideOrShowScrollBar].
	super mouseDownInSlider: event