buttonNamed: aString action: aSymbol color: aColor help: helpString

	| f col |
	f _ SimpleButtonMorph new
		target: self;
		label: aString translated font: self myFont;
		color: aColor;
		actionSelector: aSymbol;
		setBalloonText: helpString translated.
	col _ (self inAColumn: {f}) hResizing: #spaceFill.
	^col