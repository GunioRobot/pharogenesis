clearPaletteArea
	(argument ~~ nil and: [argument standardPalette ~~ nil]) ifTrue:
		[argument standardPalette showNoPalette]