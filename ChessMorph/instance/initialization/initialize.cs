initialize
	"initialize the state of the receiver"
	super initialize.
	""
	animateMove _ false.
	autoPlay _ false.

	self cornerStyle: #rounded.
	self layoutPolicy: TableLayout new.
	self listDirection: #leftToRight;
		 wrapDirection: #bottomToTop.
	self addSquares.
	self addButtonRow.
	self newGame