drawOn: aCanvas

	| s |
	super drawOn: aCanvas.
	s _ self width printString, 'x', self height printString.
	aCanvas drawString: s in: (bounds insetBy: borderWidth + 5) font: nil color: Color red.
