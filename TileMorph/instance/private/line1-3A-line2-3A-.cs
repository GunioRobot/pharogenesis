line1: line1 line2: line2

	| m1 m2 desiredW |
	self removeAllMorphs.
	m1 _ StringMorph contents: line1 font: ScriptingSystem fontForTiles.
	m2 _ StringMorph contents: line2 font: ScriptingSystem fontForTiles.
	desiredW _ (m1 width max: m2 width) + 6.
	self extent: (desiredW max: self minimumWidth) @ self class defaultH.
	m1 position: (bounds center x - (m1 width // 2) + 1)@(bounds top + 1).
	m2 position: (bounds center x - (m2 width // 2) + 1)@(m1 bottom - 2).
	self addMorph: m1; addMorph: m2.
