initialize

	super initialize.
	orientation _ #vertical.
	centering _ #center.
	hResizing _ #spaceFill.
	vResizing _ #spaceFill.
	inset _ 3.
	color _ Color veryLightGray.
	self borderWidth: 2.

	midiPortNumber _ nil.
	midiSynth _ MIDISynth new.
	instrumentSelector _ Array new: 16.

	self removeAllMorphs.
	self addMorphBack: self makeControls.
	self addMorphBack:
		(AlignmentMorph newColumn color: color; inset: 0).
	self addChannelControlsFor: 1.
	self extent: 20@20.
