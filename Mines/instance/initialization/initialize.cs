initialize
	"initialize the state of the receiver"
	super initialize.
	""
	self listDirection: #topToBottom;
	  wrapCentering: #center;
		 cellPositioning: #topCenter;
	  vResizing: #shrinkWrap;
	  hResizing: #shrinkWrap;
	  layoutInset: 3;
	  addMorph: self makeControls;
	  addMorph: self board.
	helpText _ nil.
	self newGame