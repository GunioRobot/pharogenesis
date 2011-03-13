initialize

	super initialize.
	self listDirection: #topToBottom.
	self wrapCentering: #center; cellPositioning: #topCenter.
	self hResizing: #spaceFill.
	self vResizing: #spaceFill.
	self layoutInset: 3.
	color _ Color veryLightGray.
	self borderWidth: 2.

	midiPortNumber _ nil.
	midiSynth _ MIDISynth new.
	instrumentSelector _ Array new: 16.

	self removeAllMorphs.
	self addMorphBack: self makeControls.
	self addMorphBack:
		(AlignmentMorph newColumn color: color; layoutInset: 0).
	self addChannelControlsFor: 1.
	self extent: 20@20.
