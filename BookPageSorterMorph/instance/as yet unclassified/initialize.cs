initialize

	super initialize.
	self extent: Display extent - 100;
		listDirection: #topToBottom;
		wrapCentering: #topLeft;
		hResizing: #shrinkWrap;
		vResizing: #shrinkWrap;
		layoutInset: 3;
		color: Color lightGray;
		borderWidth: 2.
	pageHolder _ PasteUpMorph new behaveLikeHolder extent: self extent - borderWidth.
	pageHolder hResizing: #shrinkWrap.
	pageHolder cursor: 0.
	self addControls.
	self addMorphBack: pageHolder.
