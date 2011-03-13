buildButtonFromSpec: spec forModel: model 
	| buttonViewClass b |
	Smalltalk isMorphic
		ifTrue: [buttonViewClass _ self morphicButtonsClass]
		ifFalse: [buttonViewClass _ PluggableButtonView].
	b _ buttonViewClass
				on: model
				getState: (self specificationFromList: spec at: 1)
				action: (self specificationFromList: spec at: 2).
	b
		label: (self specificationFromList: spec at: 3);
		 borderWidth: 1.
	b
		setBalloonText: (self specificationFromList: spec at: 4).
	^ b