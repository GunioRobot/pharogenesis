addButtons
	| r b |

	caption ifNotNil: ["Special setup for play-only interface"
		(r _ self makeARowForButtons)
			addMorphBack: (SimpleButtonMorph new target: self;
	 							label: caption; actionSelector: #play);
			addMorphBack: self makeASpacer;
			addMorphBack: self makeStatusLight;
			addMorphBack: self makeASpacer.
		^ self addMorphBack: r
	].

	(r _ self makeARowForButtons)
		addMorphBack: (b _ self buttonFor: {#record. nil. 'Begin recording'});
		addMorphBack: self makeASpacer;
		addMorphBack: (self buttonFor: {#stop. b width. 'Stop recording - you can also use the ESC key to stop it'});
		addMorphBack: self makeASpacer;
		addMorphBack: (self buttonFor: {#play. b width. 'Play current recording'}).
	self addMorphBack: r.

	(r _ self makeARowForButtons)
		addMorphBack: (b _ self buttonFor: {#writeTape. nil. 'Save current recording on disk'});
		addMorphBack: self makeASpacer;
		addMorphBack: (self buttonFor: {#readTape. b width. 'Get a new recording from disk'}).
	self addMorphBack: r.

	(r _ self makeARowForButtons)
		addMorphBack: (b _ self buttonFor: {#shrink. nil. 'Make recording shorter by removing unneeded events'});
		addMorphBack: self makeASpacer;
		addMorphBack: self makeStatusLight;
		addMorphBack: self makeASpacer;
		addMorphBack: (self buttonFor: {#button. b width. 'Make a simple button to play this recording'}).
	self addMorph: r.
	self setStatusLight: #ready.