buttonNamed: aString action: aSymbol color: aColor help: helpString

	| f col |
	f _ SimpleButtonMorph new
		target: self;
		label: aString;
		color: aColor;
		borderColor: aColor muchDarker;
		actionSelector: aSymbol;
		setBalloonText: helpString.
	col _ (self inAColumn: {f}) hResizing: #shrinkWrap.
	^col