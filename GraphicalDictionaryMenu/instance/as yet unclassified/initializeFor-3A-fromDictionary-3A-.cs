initializeFor: aTarget fromDictionary: aDictionary
	|  imageWrapper anIndex aButton controlsWrapper asm |
	self listDirection: #topToBottom.
	self addMorphBack: (controlsWrapper _ AlignmentMorph newRow).
	self baseDictionary: aDictionary.
	target _ aTarget.
	coexistWithOriginal _ true.
	color _ Color white.
	borderColor _ Color blue darker.
	borderWidth _ 1.

	self hResizing: #shrinkWrap; vResizing: #shrinkWrap.

	controlsWrapper borderWidth: 0; layoutInset: 0; hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5.
	controlsWrapper wrapCentering: #topLeft; color: Color white; vResizing: #spaceFill.
	controlsWrapper addTransparentSpacerOfSize: (18@0).
	controlsWrapper addMorphBack: (IconicButton new borderWidth: 0;
			labelGraphic: (ScriptingSystem formAtKey: 'Menu'); color: Color transparent; 
			actWhen: #buttonDown;
			actionSelector: #showMenu; target: self;
			setBalloonText: 'menu').

	controlsWrapper  addTransparentSpacerOfSize: (14@0).

	aButton _ SimpleButtonMorph new target: self; borderColor: Color black.

	controlsWrapper addMorphBack: (aButton fullCopy
		label: 'Prev';
		actionSelector: #downArrowHit;
		actWhen: #whilePressed;
		setBalloonText: 'show previous picture';
		yourself).
	controlsWrapper addTransparentSpacerOfSize: (15@0).
	controlsWrapper addMorphBack: (aButton fullCopy label: 'Next';	actionSelector: #upArrowHit; actWhen: #whilePressed; setBalloonText: 'show next pictutre').

	self addMorphBack: controlsWrapper.
	self addTransparentSpacerOfSize: (0 @ 12).

	self addMorphBack:  (asm _ UpdatingStringMorph new contents: ' '; target: self; putSelector: #renameGraphicTo:; getSelector: #truncatedNameOfGraphic; useStringFormat).
	asm setBalloonText: 'The name of the current graphic'. 
	self addTransparentSpacerOfSize: (0 @ 12).
	self addMorphBack: (AlignmentMorph newRow height: 4; borderWidth: 0; color: Color black).
	imageWrapper _ Morph new color: Color transparent; extent: 190 @ 82.
	imageWrapper addMorphBack: (formDisplayMorph _ ImageMorph new extent: 100 @ 100).
	self addMorphBack: imageWrapper.
	target ifNotNil: [(anIndex _ formChoices indexOf: target form ifAbsent: [nil]) ifNotNil:
		[currentIndex _ anIndex]].
	self updateThumbnail