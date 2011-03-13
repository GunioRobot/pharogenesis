initialize

	super initialize.
	fullDisplay _ true.
	color _ Color white.
	lastFullUpdateTime _ 0.
	self listDirection: #topToBottom;
		hResizing: #shrinkWrap;
		vResizing: #shrinkWrap.
