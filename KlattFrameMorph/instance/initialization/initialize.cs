initialize
	super initialize.
	self listDirection: #topToBottom.
	self layoutInset: 6; cellInset: 4.
	self hResizing: #shrinkWrap; vResizing: #shrinkWrap.