addControls
	| b r partsBinButton newButton |

	newButton _ ImageMorph new image: (World project makeThumbnail scaledToSize: 24@18).
	newButton on: #mouseDown send: #insertNewProject: to: self.
	newButton setBalloonText: 'Make a new Project' translated.
	(partsBinButton _ UpdatingThreePhaseButtonMorph checkBox)
		target: self;
		actionSelector: #togglePartsBinStatus;
		arguments: #();
		getSelector: #getPartsBinStatus.
	(r _ AlignmentMorph newRow)
		color: Color transparent;
		borderWidth: 0;
		layoutInset: 0;
		wrapCentering: #center;
		cellPositioning: #topCenter;
		hResizing: #shrinkWrap;
		vResizing: #shrinkWrap;
		extent: 5@5.
	b _ SimpleButtonMorph new target: self; color: self defaultColor darker;
			borderColor: Color black.
	r addMorphBack: (self wrapperFor: (b label: 'Okay' translated;	actionSelector: #acceptSort)).
	b _ SimpleButtonMorph new target: self; color: self defaultColor darker;
			borderColor: Color black.
	r addMorphBack: (self wrapperFor: (b label: 'Cancel' translated;	actionSelector: #delete));
		addMorphBack: (self wrapperFor: (newButton));
		addTransparentSpacerOfSize: 8 @ 0;
		addMorphBack: (self wrapperFor: partsBinButton);
		addMorphBack: (self wrapperFor: (StringMorph contents: 'Parts bin' translated) lock).

	self addMorphFront: r.
