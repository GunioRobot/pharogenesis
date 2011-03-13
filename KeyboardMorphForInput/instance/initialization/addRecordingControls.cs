addRecordingControls

	| button switch playRow durRow articRow modRow |
	button _ SimpleButtonMorph new target: self;
		borderColor: #raised; borderWidth: 2; color: color.
	switch _ SimpleSwitchMorph new target: self;
		offColor: color; onColor: (Color r: 1.0 g: 0.6 b: 0.6); borderWidth: 2;
		setSwitchState: false.

	"Add chord, rest and delete buttons"
	playRow _ AlignmentMorph newRow.
	playRow color: color; borderWidth: 0; layoutInset: 0.
	playRow hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5.
	playRow addMorphBack: (switch fullCopy label: 'chord'; actionSelector: #buildChord:).
	playRow addMorphBack: (button fullCopy label: '          rest          '; actionSelector: #emitRest).
	playRow addMorphBack: (button fullCopy label: 'del'; actionSelector: #deleteNotes).
	self addMorph: playRow.
	playRow align: playRow bounds topCenter
			with: self bounds bottomCenter.

	"Add note duration buttons"
	durRow _ AlignmentMorph newRow.
	durRow color: color; borderWidth: 0; layoutInset: 0.
	durRow hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5.
	durRow addMorphBack: (switch fullCopy label: 'whole';
				actionSelector: #duration:onOff:; arguments: #(1)).
	durRow addMorphBack: (switch fullCopy label: 'half';
				actionSelector: #duration:onOff:; arguments: #(2)).
	durRow addMorphBack: (switch fullCopy label: 'quarter';
				actionSelector: #duration:onOff:; arguments: #(4)).
	durRow addMorphBack: (switch fullCopy label: 'eighth';
				actionSelector: #duration:onOff:; arguments: #(8)).
	durRow addMorphBack: (switch fullCopy label: 'sixteenth';
				actionSelector: #duration:onOff:; arguments: #(16)).
	self addMorph: durRow.
	durRow align: durRow bounds topCenter
			with: playRow bounds bottomCenter.

	"Add note duration modifier buttons"
	modRow _ AlignmentMorph newRow.
	modRow color: color; borderWidth: 0; layoutInset: 0.
	modRow hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5.
	modRow addMorphBack: (switch fullCopy label: 'dotted';
				actionSelector: #durMod:onOff:; arguments: #(dotted)).
	modRow addMorphBack: (switch fullCopy label: 'normal';
				actionSelector: #durMod:onOff:; arguments: #(normal)).
	modRow addMorphBack: (switch fullCopy label: 'triplets';
				actionSelector: #durMod:onOff:; arguments: #(triplets)).
	modRow addMorphBack: (switch fullCopy label: 'quints';
				actionSelector: #durMod:onOff:; arguments: #(quints)).
	self addMorph: modRow.
	modRow align: modRow bounds topCenter
			with: durRow bounds bottomCenter.

	"Add articulation buttons"
	articRow _ AlignmentMorph newRow.
	articRow color: color; borderWidth: 0; layoutInset: 0.
	articRow hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5.
	articRow addMorphBack: (switch fullCopy label: 'legato';
				actionSelector: #articulation:onOff:; arguments: #(legato)).
	articRow addMorphBack: (switch fullCopy label: 'normal';
				actionSelector: #articulation:onOff:; arguments: #(normal)).
	articRow addMorphBack: (switch fullCopy label: 'staccato';
				actionSelector: #articulation:onOff:; arguments: #(staccato)).
	self addMorph: articRow.
	articRow align: articRow bounds topCenter
			with: modRow bounds bottomCenter.

	self bounds: (self fullBounds expandBy: (0@0 extent: 0@borderWidth))
