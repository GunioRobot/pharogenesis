initialize
	"initialize the state of the receiver"
	super initialize.
	""
	
	self extent: 30 @ 37.
	self addMorphFront: (iris := EllipseMorph new extent: 6 @ 6;
					 borderWidth: 0;
					 color: Color black).
	self lookAtFront