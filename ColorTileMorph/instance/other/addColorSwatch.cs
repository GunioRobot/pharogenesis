addColorSwatch

	| m1 m2 desiredW |
	m1 _ StringMorph contents: 'color' translated font: ScriptingSystem fontForTiles.
	m2 _ Morph new extent: 12@8; color: (Color r: 0.8 g: 0 b: 0).
	desiredW _ m1 width + 6.
	self extent: (desiredW max: self basicWidth) @ self class defaultH.
	m1 position: (bounds center x - (m1 width // 2)) @ (bounds top + 1).
	m2 position: (bounds center x - (m2 width // 2)) @ (m1 bottom - 1).
	self addMorph: m1; addMorph: m2.
	colorSwatch _ m2