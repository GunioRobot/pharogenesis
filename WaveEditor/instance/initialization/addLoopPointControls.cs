addLoopPointControls

	| r m |
	r _ AlignmentMorph newRow.
	r color: self color; borderWidth: 0; layoutInset: 0.
	r hResizing: #spaceFill; vResizing: #rigid; extent: 5@20; wrapCentering: #center; cellPositioning: #leftCenter.

	m _ StringMorph new contents: 'Loop end: '.
	r addMorphBack: m.
	m _ UpdatingStringMorph new
		target: self; getSelector: #loopEnd; putSelector: #loopEnd:;
		growable: false; width: 50; step.
	r addMorphBack: m.

	m _ StringMorph new contents: 'Loop length: '.
	r addMorphBack: m.
	m _ UpdatingStringMorph new
		target: self; getSelector: #loopLength; putSelector: #loopLength:;
		floatPrecision: 0.001;
		growable: false; width: 50; step.
	r addMorphBack: m.

	m _ StringMorph new contents: 'Loop cycles: '.
	r addMorphBack: m.
	m _ UpdatingStringMorph new
		target: self; getSelector: #loopCycles; putSelector: #loopCycles:;
		floatPrecision: 0.001;
		growable: false; width: 50; step.
	r addMorphBack: m.

	m _ StringMorph new contents: 'Frequency: '.
	r addMorphBack: m.
	m _ UpdatingStringMorph new
		target: self; getSelector: #perceivedFrequency; putSelector: #perceivedFrequency:;
		floatPrecision: 0.001;
		growable: false; width: 50; step.
	r addMorphBack: m.

	self addMorphBack: r.
