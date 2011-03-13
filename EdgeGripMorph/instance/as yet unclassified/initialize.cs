initialize
	"Initialize the receiver."
	
	super initialize.
	self
		edgeName: #right;
		extent: self defaultWidth+2 @ (self defaultHeight+2);
		hResizing: #spaceFill;
		vResizing: #spaceFill