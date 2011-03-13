addPhonemeDisplay
	"Add a display to show the currently matching phoneme."

	| font r |
	font := StrikeFont familyName: 'Helvetica' size: 36.
	phonemeDisplay := StringMorph contents: '...' font: font.
	r := AlignmentMorph newColumn
		color: color;
		layoutInset: 0;
		wrapCentering: #center; cellPositioning: #topCenter;
		hResizing: #spaceFill;
		vResizing: #rigid;
		height: 20.
	r addMorphBack: phonemeDisplay.
	self addMorphBack: (Morph new extent: 5@8; color: Color transparent).  "spacer"
	self addMorphBack: r.
