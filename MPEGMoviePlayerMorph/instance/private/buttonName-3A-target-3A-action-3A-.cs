buttonName: aString target: anObject action: selector
	"private - create a button"

	^ SimpleButtonMorph new
		target: anObject;
		label: aString;
		actionSelector: selector;
		color: (Color gray: 0.8);  "old color"
		fillStyle: self buttonFillStyle;
		borderWidth: 0;
		borderColor: #raised.
