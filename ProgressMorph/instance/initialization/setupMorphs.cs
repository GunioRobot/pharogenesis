setupMorphs
	|  |
	self initProgressMorph.
	self	
		layoutPolicy: TableLayout new;
		listDirection: #topToBottom;
		cellPositioning: #topCenter;
		listCentering: #center;
		hResizing: #shrinkWrap;
		vResizing: #shrinkWrap;
		color: Color transparent.

	self addMorphBack: self labelMorph.
	self addMorphBack: self subLabelMorph.
	self addMorphBack: self progress.

	self borderWidth: 2.
	self borderColor: Color black.

	self color: Color veryLightGray.
	self align: self fullBounds center with: Display boundingBox center
