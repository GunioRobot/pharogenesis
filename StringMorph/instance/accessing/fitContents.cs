fitContents
	| scanner |
	scanner _ QuickPrint newOn: Display box: Display boundingBox font: font.
	self extent: (scanner stringWidth: contents) @ (scanner lineHeight).
	self changed