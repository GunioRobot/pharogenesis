buttonName: aString action: aSymbol
	"Create a button of the given name to send myself the given unary message."

	^ SimpleButtonMorph new
		target: self;
		label: aString;
		actionSelector: aSymbol
