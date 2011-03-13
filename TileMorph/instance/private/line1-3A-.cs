line1: line1

	| m desiredW |

	self removeAllMorphs.
	m _ StringMorph contents: line1 font: ScriptingSystem fontForTiles.
	desiredW _ m width + 6.
	self extent: (desiredW max: self minimumWidth) @ self class defaultH.
	m position: self center - (m extent // 2).
	self addMorph: m.
