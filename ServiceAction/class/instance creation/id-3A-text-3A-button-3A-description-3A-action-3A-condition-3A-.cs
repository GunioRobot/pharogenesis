id: aSymbol text: aStringOrBlock button: buttonString description: aString action: aBlock condition: cBlock
	^ (self new) 
		id: aSymbol;
		text: aStringOrBlock; 
		buttonLabel: buttonString; 
		description: aString; 
		action: aBlock;
		condition: cBlock;
		yourself