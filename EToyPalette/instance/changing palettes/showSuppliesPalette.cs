showSuppliesPalette
	self highlightPaletteName: self labelForSuppliesPalette.
	suppliesPalette ifNil: [suppliesPalette _ self suppliesBook].
	self showPalette: suppliesPalette
