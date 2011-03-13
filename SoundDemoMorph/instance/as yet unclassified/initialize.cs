initialize

	super initialize.
	self listDirection: #topToBottom.
	self wrapCentering: #center; cellPositioning: #topCenter.
	self hResizing: #spaceFill.
	self vResizing: #spaceFill.
	self layoutInset: 3.
	color _ Color lightGray.
	self borderWidth: 2.
	self addMorph: self makeControls.
	soundColumn _ AlignmentMorph newColumn.
	soundColumn enableDragNDrop.
	self addMorphBack: soundColumn.
	self extent: 118@150.

