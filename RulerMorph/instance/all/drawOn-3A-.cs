drawOn: aCanvas

	| s |
	super drawOn: aCanvas.
	s _ self width printString, 'x', self height printString.
	aCanvas text: s bounds: (bounds insetBy: borderWidth + 5) font: nil color: Color red.
