addControls

	| bb r aButton str |
	r _ AlignmentMorph newRow color: Color transparent; borderWidth: 0; layoutInset: 0.
	r wrapCentering: #center; cellPositioning: #topCenter; 
			hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5.
	bb _ SimpleButtonMorph new target: self; borderColor: Color black.
	r addMorphBack: (self wrapperFor: (bb label: 'Okay' translated;	actionSelector: #acceptSort)).
	bb _ SimpleButtonMorph new target: self; borderColor: Color black.
	r addMorphBack: (self wrapperFor: (bb label: 'Cancel' translated;	actionSelector: #delete)).

	r addTransparentSpacerOfSize: 8 @ 0.
	r addMorphBack: (self wrapperFor: (aButton _ UpdatingThreePhaseButtonMorph checkBox)).
	aButton
		target: self;
		actionSelector: #togglePartsBinStatus;
		arguments: #();
		getSelector: #getPartsBinStatus.
	str _ StringMorph contents: 'Parts bin' translated.
	r addMorphBack: (self wrapperFor: str lock).

	self addMorphFront: r.
