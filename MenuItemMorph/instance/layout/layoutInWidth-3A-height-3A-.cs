layoutInWidth: w height: h

	| scanner |
	scanner _ QuickPrint newOn: Display box: Display boundingBox font: font.
	self extent: ((scanner stringWidth: contents) @ (scanner lineHeight) max: w@h).
