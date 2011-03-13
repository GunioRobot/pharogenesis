initialize
	super initialize.
	synthesizer := KlattSynthesizer new cascade: 0.
	self segments: KlattSegmentSet arpabet.
	self patternFrame: self defaultPatternFrame.
	self breathiness: 0.0.
	self tract: 17.3. "Set a male vocal tract."
	self reset