addControls
	| chooser |
	chooser _ PopUpChoiceMorph new extent: 90@14;
		contentsClipped: 'edit ' , envelope name;
		target: self;
		actionSelector: #chooseFrom:envelopeItem:;
		getItemsSelector: #curveChoices.
	chooser arguments: (Array with: chooser).
	self addMorph: chooser.
	chooser position: bounds bottomCenter - (35@40).

	chooser _ PopUpChoiceMorph new extent: 110@14;
		contentsClipped: whatToPlay;
		target: self;
		actionSelector: #sampleToPlay:;
		getItemsSelector: #sampleChoices.
	self addMorph: chooser.
	chooser position: bounds bottomCenter - (90@20).

	chooser _ PopUpChoiceMorph new extent: 90@14;
		contentsClipped: playMode;
		target: self;
		actionSelector: #setPlayMode:;
		getItemsSelector: #playChoices.
	self addMorph: chooser.
	chooser position: bounds bottomCenter - (-20@20).
