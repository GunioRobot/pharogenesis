initialize
	"initialize the state of the receiver"
	super initialize.
	""
	fullDisplay _ false.
	
	lastFullUpdateTime _ 0.
	self listDirection: #topToBottom;
		 hResizing: #shrinkWrap;
		 vResizing: #shrinkWrap