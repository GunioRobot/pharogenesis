initialize
	"initialize the state of the receiver"
	super initialize.
	""
	self listDirection: #topToBottom.
	self hResizing: #shrinkWrap.
	"<--so naked buttons work right"
	self vResizing: #shrinkWrap.
	self wrapCentering: #center;
		 cellPositioning: #topCenter.
	model _ nil.
	label _ nil.
	getStateSelector _ nil.
	actionSelector _ nil.
	getLabelSelector _ nil.
	getMenuSelector _ nil.
	shortcutCharacter _ nil.
	askBeforeChanging _ false.
	triggerOnMouseDown _ false.
	onColor _ self color darker.
	offColor _ self color.
	feedbackColor _ Color red.
	showSelectionFeedback _ false.
	allButtons _ nil.
	argumentsProvider _ nil.
	argumentsSelector _ nil.
	self extent: 20 @ 15