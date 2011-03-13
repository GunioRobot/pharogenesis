initialize
	super initialize.
	self listDirection: #topToBottom.
	self wrapCentering: #center; cellPositioning: #topCenter.
	self vResizing: #shrinkWrap.
	self hResizing: #shrinkWrap.
	self layoutInset: 3.
	color _ Color lightGray.
	self addMorph: self makeControls.
	self addMorph: self board.
	helpText _ nil.
	self newGame.