addControls

	| b r aButton str |
	b _ SimpleButtonMorph new target: self; borderColor: Color black.
	r _ AlignmentMorph newRow color: Color transparent; borderWidth: 0; layoutInset: 0.
	r wrapCentering: #center; cellPositioning: #topCenter; hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5.
	r addMorphBack: (self wrapperFor: (b fullCopy label: 'Okay';	actionSelector: #acceptSort)).
	r addMorphBack: (self wrapperFor: (b fullCopy label: 'Cancel';	actionSelector: #delete)).

	r addTransparentSpacerOfSize: 8 @ 0.
	r addMorphBack: (self wrapperFor: (aButton _ UpdatingThreePhaseButtonMorph checkBox)).
	aButton
		target: self;
		actionSelector: #togglePartsBinStatus;
		arguments: #();
		getSelector: #getPartsBinStatus.
	str _ StringMorph contents: 'Parts bin'.
	r addMorphBack: (self wrapperFor: str lock).

	self addMorphFront: r.
