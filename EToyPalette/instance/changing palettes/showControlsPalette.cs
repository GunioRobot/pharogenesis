showControlsPalette
	self highlightPaletteName: self labelForControlsPalette.
	controlsPalette ifNil: [controlsPalette _ self controlsBook].
	self showPalette: controlsPalette
