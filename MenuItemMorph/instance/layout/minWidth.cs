minWidth

	| scanner |
	scanner _ DisplayScanner quickPrintOn: Display box: Display boundingBox font: self fontToUse.
	^ (scanner stringWidth: contents) + (subMenu == nil ifTrue: [0] ifFalse: [10])
