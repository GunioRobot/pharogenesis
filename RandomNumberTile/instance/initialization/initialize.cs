initialize
	| m1 m2 |
	super initialize.
	self typeColor: (ScriptingSystem colorForType: #number).
	self addArrows.
	m1 _ StringMorph contents: 'random' font: ScriptingSystem fontForTiles.
	self addMorph: m1.
	m2 _ UpdatingStringMorph contents: '180' font: ScriptingSystem fontForTiles.
	m2 target: self; getSelector: #literal; putSelector: #literal:.
	m2 position: m1 topRight.
	self addMorphBack: m2.
	literal _ 180.
	self updateLiteralLabel