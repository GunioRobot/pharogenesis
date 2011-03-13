drawRolloverBorderOn: aCanvas

	| colorToUse offsetToUse myShadow newForm f |

	colorToUse _ self valueOfProperty: #rolloverColor ifAbsent: [Color blue alpha: 0.5].
	offsetToUse _ self valueOfProperty: #rolloverWidth ifAbsent: [10@10].

	self hasRolloverBorder: false.
	myShadow _ self shadowForm.
	self hasRolloverBorder: true.

	myShadow offset: 0@0.
	f _ ColorForm extent: myShadow extent depth: 1.
	myShadow displayOn: f.
	f colors: {Color transparent. colorToUse}.

	newForm _ Form extent: offsetToUse * 2 + myShadow extent depth: 32.
     (WarpBlt current toForm: newForm)
		sourceForm: f;
		cellSize: 2; 
		combinationRule: 3;
		copyQuad: f boundingBox innerCorners toRect: newForm boundingBox.
	aCanvas 
		translateBy: offsetToUse negated
		during: [ :shadowCanvas |
			shadowCanvas shadowColor: colorToUse.
			shadowCanvas paintImage: newForm at: self position.
		].

