addControls

	| b r |
	b _ SimpleButtonMorph new target: self; borderColor: Color black.
	r _ AlignmentMorph newRow.
	r color: b color; borderWidth: 0; layoutInset: 0.
	r hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5.
	r wrapCentering: #topLeft.
	r addMorphBack: (b label: 'Okay';	actionSelector: #acceptSort).
	b _ SimpleButtonMorph new target: self; borderColor: Color black.
	r addMorphBack: (b label: 'Cancel';	actionSelector: #cancelSort).
	self addMorphFront: r.
