addControls

	| slider b r m |
	b _ SimpleButtonMorph new target: self; borderColor: Color black.
	r _ AlignmentMorph newRow.
	r color: b color; borderWidth: 0; layoutInset: 0.
	r hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5.
	r wrapCentering: #topLeft.
	r addMorphBack: (b fullCopy label: 'X';					actionSelector: #delete).
	r addMorphBack: (b fullCopy label: '<>'; actWhen: #buttonDown;
															actionSelector: #invokeMenu).
	r addMorphBack: (b fullCopy label: 'Play';				actionSelector: #play).
	r addMorphBack: (b fullCopy label: 'Play Before';		actionSelector: #playBeforeCursor).
	r addMorphBack: (b fullCopy label: 'Play After';			actionSelector: #playAfterCursor).
	r addMorphBack: (b fullCopy label: 'Play Loop';			actionSelector: #playLoop).
	r addMorphBack: (b fullCopy label: 'Test';				actionSelector: #playTestNote).
	r addMorphBack: (b fullCopy label: 'Save';				actionSelector: #saveInstrument).
	r addMorphBack: (b fullCopy label: 'Set Loop End';		actionSelector: #setLoopEnd).
	r addMorphBack: (b fullCopy label: 'One Cycle';			actionSelector: #setOneCycle).
	r addMorphBack: (b fullCopy label: 'Set Loop Start';		actionSelector: #setLoopStart).
	self addMorphBack: r.

	r _ AlignmentMorph newRow.
	r color: self color; borderWidth: 0; layoutInset: 0.
	r hResizing: #spaceFill; vResizing: #rigid; extent: 5@20; wrapCentering: #center; cellPositioning: #leftCenter.

	m _ StringMorph new contents: 'Index: '.
	r addMorphBack: m.
	m _ UpdatingStringMorph new
		target: graph; getSelector: #cursor; putSelector: #cursor:;
		growable: false; width: 71; step.
	r addMorphBack: m.

	m _ StringMorph new contents: 'Value: '.
	r addMorphBack: m.
	m _ UpdatingStringMorph new
		target: graph; getSelector: #valueAtCursor; putSelector: #valueAtCursor:;
		growable: false; width: 50; step.
	r addMorphBack: m.

	slider _ SimpleSliderMorph new
		color: color;
		extent: 200@2;
		target: self;
		actionSelector: #scrollTime:.
	r addMorphBack: slider.

	m _ Morph new color: r color; extent: 10@5.  "spacer"
	r addMorphBack: m.
	m _ UpdatingStringMorph new
		target: graph; getSelector: #startIndex; putSelector: #startIndex:;
		width: 40; step.
	r addMorphBack: m.

	self addMorphBack: r.

