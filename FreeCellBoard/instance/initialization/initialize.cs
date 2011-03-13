initialize

	super initialize.
	self listDirection: #topToBottom.
	self hResizing: #shrinkWrap.
	self vResizing: #rigid.
	self height: 500.
	borderWidth _ 0.
	color _ Color green.
	self layout.
