initialize

	super initialize.
	self extent: Display extent - 100;
		orientation: #vertical;
		centering: #topLeft;
		hResizing: #shrinkWrap;
		vResizing: #shrinkWrap;
		inset: 3;
		color: Color lightGray;
		borderWidth: 2.
	pageHolder _ PasteUpMorph new behaveLikeHolder extent: self extent - borderWidth.
	pageHolder cursor: 0.
	self addControls.
	self addMorphBack: pageHolder.
