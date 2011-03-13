initialize
	super initialize.
	saved _ true.
	borderWidth _ 2.
	borderColor _ #raised.
	color _ Color red.
	self listDirection: #topToBottom.
	self wrapCentering: #center; cellPositioning: #topCenter.
	self hResizing: #shrinkWrap.
	self vResizing: #shrinkWrap.
	self layoutInset: 2.
	self minCellSize: 4.
	self addButtons.
