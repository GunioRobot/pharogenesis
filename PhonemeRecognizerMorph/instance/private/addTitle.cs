addTitle
	"Add a title."

	| font title r |
	font _ StrikeFont familyName: Preferences standardEToysFont familyName size: 20.
	title _ StringMorph contents: 'Phoneme Recognizer' font: font.
	r _ AlignmentMorph newColumn
		color: color;
		layoutInset: 0;
		wrapCentering: #center; cellPositioning: #topCenter;
		hResizing: #spaceFill;
		vResizing: #rigid;
		height: 20.
	r addMorphBack: title.
	self addMorphBack: r.
	self addMorphBack: (Morph new extent: 5@8; color: Color transparent).  "spacer"
