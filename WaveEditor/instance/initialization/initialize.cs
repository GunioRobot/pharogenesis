initialize

	super initialize.
	samplingRate _ SoundPlayer samplingRate.
	loopEnd _ loopLength _ 0.
	loopCycles _ 1.
	perceivedFrequency _ 0.  "zero means unknown"
	self extent: 5@5;
		orientation: #vertical;
		centering: #topLeft;
		hResizing: #shrinkWrap;
		vResizing: #shrinkWrap;
		inset: 3;
		color: Color lightGray;
		borderWidth: 2.
	graph _ GraphMorph new extent: 450@100.
	graph cursor: 0.
	graph cursorColorAtZeroCrossings: Color blue.
	self addControls.
	self addLoopPointControls.
	self addMorphBack: graph.
	self addMorphBack: (Morph newBounds: (0@0 extent: 0@3) color: Color transparent).
	self addMorphBack: (keyboard _ PianoKeyboardMorph new).
