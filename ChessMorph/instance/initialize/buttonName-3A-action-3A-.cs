buttonName: aString action: aSymbol

	^ SimpleButtonMorph new
		target: self;
		label: aString;
		actionSelector: aSymbol;
		color: (Color gray: 0.8);  "old color"
		fillStyle: self buttonFillStyle;
		borderWidth: 0;
		borderColor: #raised.
