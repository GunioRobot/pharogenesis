initializeSoundColumn
"initialize the receiver's soundColumn"
	soundColumn _ AlignmentMorph newColumn.
	soundColumn enableDragNDrop.
	self addMorphBack: soundColumn