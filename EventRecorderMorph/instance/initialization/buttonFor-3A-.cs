buttonFor: aSymbol 
	^ SimpleButtonMorph new target: self;
	 label: aSymbol asString;
	 actionSelector: aSymbol