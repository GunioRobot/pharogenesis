initialize

 	super initialize.
	orientation _ #vertical.
	hResizing _ vResizing _ #spaceFill.
	centering _ #center.
	borderWidth _ 1.
	model _ nil.
	label _ nil.
	getStateSelector _ nil.
	actionSelector _ nil.
	getLabelSelector _ nil.
	getMenuSelector _ nil.
	shortcutCharacter _ nil.
	askBeforeChanging _ false.
	triggerOnMouseDown _ false.
	color _ Color lightGreen.
	onColor _ color darker.
	offColor _ color.
	feedbackColor _ Color red.
	showSelectionFeedback _ false.
	allButtons _ nil.
	self extent: 20@15.
