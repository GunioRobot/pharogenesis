doPages

	| dialog |
	(dialog _ GeePrinterDialogMorph new) 
		printSpecs: self printSpecs 
		printBlock: [ :preview :specs |
			preview ifTrue: [self doPrintPreview] ifFalse: [self doPrintToPrinter]
		];
		fullBounds;
		position: Display extent - dialog extent // 2;
		openInWorld

