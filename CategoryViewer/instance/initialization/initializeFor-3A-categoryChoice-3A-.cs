initializeFor: aPlayer categoryChoice: aChoice
	self orientation: #vertical;
		hResizing: #spaceFill;
		vResizing: #spaceFill;
		borderWidth: 1;
		beSticky.
	self color: Color green muchLighter muchLighter.
	scriptedPlayer _ aPlayer.
	self addHeaderMorph.

	self categoryChoice: aChoice
