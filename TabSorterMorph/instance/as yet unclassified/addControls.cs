addControls

	| b r |
	b _ SimpleButtonMorph new target: self; borderColor: Color black.
	r _ AlignmentMorph newRow.
	r color: b color; borderWidth: 0; inset: 0.
	r hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5.
	r centering: #topLeft.
	r addMorphBack: (b fullCopy label: 'Okay';	actionSelector: #acceptSort).
	r addMorphBack: (b fullCopy label: 'Cancel';	actionSelector: #cancelSort).
	self addMorphFront: r.
