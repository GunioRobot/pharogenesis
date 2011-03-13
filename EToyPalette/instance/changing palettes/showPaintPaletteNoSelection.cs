showPaintPaletteNoSelection

	self highlightPaletteName: self labelForPaintPalette.
	paintPalette ifNil: [paintPalette _ PaintBoxMorph new].
	self showPalette: paintPalette.
	self world stopRunningAll.
	^ paintPalette
