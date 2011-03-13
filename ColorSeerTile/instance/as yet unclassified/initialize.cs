initialize

	| m1 m2 desiredW |
	super initialize.
	self removeAllMorphs.	"get rid of the parts of a regular Color tile"
	type _ #operator.
	operatorOrExpression _ #color:sees:.
	m1 _ StringMorph new initWithContents: 'color    sees' font: ScriptingSystem fontForTiles.
	m2 _ Morph new extent: 12@8; color: (Color r: 0.8 g: 0 b: 0).
	desiredW _ m1 width + 6.
	self extent: (desiredW max: self class defaultW) @ self class defaultH.
	m1 position: (bounds center x - (m1 width // 2)) @ (bounds top + 5).
	m2 position: (bounds center x - (m2 width // 2) + 3) @ (bounds top + 8).
	self addMorph: m1; addMorphFront: m2.
	colorSwatch _ m2.
	