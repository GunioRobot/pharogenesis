makeControls

	| bb r |
	bb := SimpleButtonMorph new
		target: self;
		borderColor: #raised;
		borderWidth: 2.
	r := AlignmentMorph newRow.
	r hResizing: #spaceFill; vResizing: #spaceFill; layoutInset: 2.
	r addMorphBack: (bb label: 'Make movie';		actionSelector: #makeMovie).
	^r