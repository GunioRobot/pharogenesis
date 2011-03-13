addPhonemeDisplay
	"Add a display to show the currently matching phoneme."

	| font r |
	font _ StrikeFont familyName: 'Helvetica' size: 36.
	phonemeDisplay _ StringMorph contents: '...' font: font.
	r _ AlignmentMorph newColumn
		color: color;
		layoutInset: 0;
		wrapCentering: #center; cellPositioning: #topCenter;
		hResizing: #spaceFill;
		vResizing: #rigid;
		height: 20.
	r addMorphBack: phonemeDisplay.
	self addMorphBack: (Morph new extent: 5@8; color: Color transparent).  "spacer"
	self addMorphBack: r.
