layoutInWidth: w height: h

	| scanner |
	scanner _ DisplayScanner quickPrintOn: Display box: Display boundingBox font: self fontToUse.
	self extent: ((scanner stringWidth: contents) @ (scanner lineHeight) max: w@h).
