initialize
	"initialize the state of the receiver"
	super initialize.
	""
	self addMorph: (yScrollBar _ self createScrollBarNamed: 'yScrollBar');
		 addMorph: (xScrollBar _ self createScrollBarNamed: 'xScrollBar');
		 addMorph: (scroller _ self createScroller).
	""
	self extent: 150 @ 120