makeControls

	| b r |
	b _ SimpleButtonMorph new
		target: self;
		borderColor: #raised;
		borderWidth: 2.
	r _ AlignmentMorph newRow.
	r hResizing: #spaceFill; vResizing: #spaceFill; inset: 2.
	r addMorphBack: (b fullCopy label: 'Make movie';		actionSelector: #makeMovie).
	^r