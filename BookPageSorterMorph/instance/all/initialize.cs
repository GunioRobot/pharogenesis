initialize

	super initialize.
	self extent: 440@400;
		orientation: #vertical;
		centering: #topLeft;
		hResizing: #spaceFill;
		vResizing: #spaceFill;
		inset: 3;
		color: Color lightGray;
		borderWidth: 2.
	pageHolder _ HolderMorph new extent: self extent - borderWidth.
	pageHolder cursor: 0.
	self addControls.
	self addMorphBack: pageHolder.
