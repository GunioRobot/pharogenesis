addControls
	| chooser |
	chooser _ PopUpChoiceMorph new extent: 110@14;
		contentsClipped: 'editing ' , envelope name;
		target: self;
		actionSelector: #chooseFrom:envelopeItem:;
		getItemsSelector: #curveChoices.
	chooser arguments: (Array with: chooser).
	self addMorph: chooser.
	chooser align: chooser bounds topLeft with: graphArea bounds bottomLeft + (0@5).

	chooser _ PopUpChoiceMorph new extent: 110@14;
		contentsClipped: 'duration: ' , self durationName;
		target: self;
		actionSelector: #chooseFrom:durationItem:;
		getItemsSelector: #durationChoices.
	chooser arguments: (Array with: chooser).
	self addMorph: chooser.
	chooser align: chooser bounds topRight with: graphArea bounds bottomRight + (-50@5).
