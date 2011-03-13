initialize

	super initialize.
	acceptOnCR _ true.
	self listDirection: #topToBottom.
	color _ Color paleYellow.
	self layoutInset: 0.
	borderColor _ self standardBorderColor.
	borderWidth _ 8.
	self hResizing: #shrinkWrap.
	self vResizing: #shrinkWrap.
	self rubberBandCells: false.
	self minWidth: 200.
	self minHeight: 200.
	bounds _ 400@100 extent:  200@150.
	self rebuild.
