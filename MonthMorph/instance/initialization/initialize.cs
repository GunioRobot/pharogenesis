initialize
	"initialize the state of the receiver"
	super initialize.
	""
	tileRect _ 0 @ 0 extent: 23 @ 19.
	self 
		layoutInset: 1;
		listDirection: #topToBottom;
		vResizing: #shrinkWrap;
		hResizing: #shrinkWrap;
		month: Month current.

	self rubberBandCells: false.
	self extent: 160 @ 130