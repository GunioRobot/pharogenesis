fitContents

	| scanner |
	scanner _ DisplayScanner quickPrintOn: Display box: Display boundingBox font: self fontToUse.
	self extent: (((scanner stringWidth: contents) max: self minimumWidth)  @ scanner lineHeight).
	self changed