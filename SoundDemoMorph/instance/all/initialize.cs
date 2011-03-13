initialize

	super initialize.
	orientation _ #vertical.
	centering _ #center.
	hResizing _ #spaceFill.
	vResizing _ #spaceFill.
	inset _ 3.
	color _ Color lightGray.
	self borderWidth: 2.
	self addMorph: self makeControls.
	soundColumn _ AlignmentMorph newColumn.
	soundColumn openToDragNDrop: true.
	self addMorphBack: soundColumn.
	self extent: 118@150.

