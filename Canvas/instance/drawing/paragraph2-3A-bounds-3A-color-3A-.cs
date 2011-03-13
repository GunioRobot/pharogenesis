paragraph2: para bounds: bounds color: c

	| scanner |
	scanner _ CanvasCharacterScanner new.
	scanner
		 canvas: self;
		text: para text textStyle: para textStyle;
		textColor: c.

	para displayOn: self using: scanner at: bounds topLeft.
