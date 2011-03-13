line1: line1

	| label |
	self removeAllMorphs.

	label _ 	StringMorph contents: 'bounce on' translated font: ScriptingSystem fontForTiles.

	self addMorphBack: label.
	self addMorphBack: playerTile.
