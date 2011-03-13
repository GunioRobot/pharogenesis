buildButtonFromSpec: spec withBlock: aBlock 
	| b buttonViewClass |
	Smalltalk isMorphic
		ifTrue: [buttonViewClass _ self morphicButtonsClass]
		ifFalse: [buttonViewClass _ PluggableButtonView].
	b _ buttonViewClass new
				model: (Button new onAction: aBlock);
				
				action: (self specificationFromList: spec at: 1);
				
				label: (self specificationFromList: spec at: 2);
				 borderWidth: 1.
	b
		setBalloonText: (self specificationFromList: spec at: 3).
	^ b