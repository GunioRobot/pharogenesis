minWidth

	| scanner |
	scanner _ QuickPrint newOn: Display box: Display boundingBox font: font.
	^ (scanner stringWidth: contents) + (subMenu == nil ifTrue: [0] ifFalse: [10])
