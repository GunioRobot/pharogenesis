addButtonRows
	"Create and add my button row."

	| r |
	r := AlignmentMorph newRow vResizing: #shrinkWrap.
	r addMorphBack: ((self buttonName: 'Menu' action: #invokeMenu)
		actWhen: #buttonDown).
	r addMorphBack: (Morph new extent: 4@1; color: Color transparent).
	r addMorphBack: (self buttonName: 'Add' action: #addPhoneme).
	r addMorphBack: (Morph new extent: 4@1; color: Color transparent).
	r addMorphBack: (self buttonName: 'Run' action: #startRecognizing).
	r addMorphBack: (Morph new extent: 4@1; color: Color transparent).
	r addMorphBack: (self buttonName: 'Stop' action: #stopRecognizing).
	r addMorphBack: (Morph new extent: 4@1; color: Color transparent).
	r addMorphBack: self makeStatusLight.
	self addMorphBack: r.
