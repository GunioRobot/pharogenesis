initialize
	super initialize.
	tileRect _ 0@0 extent: 23@19.
	self layoutInset: 1;
		color: Color red;
		listDirection: #topToBottom;
		vResizing: #shrinkWrap;
		hResizing: #shrinkWrap;
		month: Date today month.
	self rubberBandCells: false.
	self extent: 160@130.