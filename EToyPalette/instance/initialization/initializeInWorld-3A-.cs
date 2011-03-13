initializeInWorld: aWorld
	color _ (Color r: 0.0 g: 0.6 b: 0.6).
	self addPalettes.
	currentPalette _ nil.
	paletteOffset _ -4@10.
	self addPaletteTabs.
	self extent: 5@5.
