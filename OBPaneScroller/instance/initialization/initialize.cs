initialize
	super initialize.
	self 
		color: Color red;
		borderWidth: 0;
		vResizing: #spaceFill;
		hResizing: #spaceFill.
	self 
		initializeTransform;
		initializeScrollbar.
	self startStepping.