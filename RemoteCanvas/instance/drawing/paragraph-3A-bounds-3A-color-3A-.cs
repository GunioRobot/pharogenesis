paragraph: paragraph bounds: bounds color: c

	| scanner |
	scanner _ CanvasCharacterScanner new.
	scanner
		 canvas: self;
		text: paragraph text textStyle: paragraph textStyle;
		textColor: c; defaultTextColor: c.

	paragraph displayOn: self using: scanner at: bounds topLeft.
