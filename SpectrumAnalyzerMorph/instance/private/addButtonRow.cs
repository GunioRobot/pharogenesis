addButtonRow

	| r |
	r _ AlignmentMorph newRow vResizing: #shrinkWrap.
	r addMorphBack: (self buttonName: 'Menu' action: #invokeMenu).
	r addMorphBack: (Morph new extent: 4@1; color: Color transparent).
	r addMorphBack: (self buttonName: 'Start' action: #start).
	r addMorphBack: (Morph new extent: 4@1; color: Color transparent).
	r addMorphBack: (self buttonName: 'Stop' action: #stop).
	r addMorphBack: (Morph new extent: 12@1; color: Color transparent).
	r addMorphBack: self makeStatusLight.
	self addMorphBack: r.
