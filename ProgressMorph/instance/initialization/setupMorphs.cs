setupMorphs
	| container  |
	self initProgressMorph.
	container _ AlignmentMorph newColumn.
	container
		wrapCentering: #center; cellPositioning: #topCenter;
		hResizing: #shrinkWrap;
		vResizing: #shrinkWrap;
		color: Color transparent.

	container addMorphBack: self labelMorph.
	container addMorphBack: self subLabelMorph.
	container addMorphBack: self progress.

	self addMorph: container.
	self borderWidth: 2.
	self borderColor: Color black.

	self extent: container extent.
	self color: Color veryLightGray.
	self align: self fullBounds center with: Display boundingBox center
