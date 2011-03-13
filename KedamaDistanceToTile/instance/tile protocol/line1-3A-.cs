line1: line1

	| label |
	self removeAllMorphs.

	label _ 	StringMorph contents: 'distanceTo' translated font: ScriptingSystem fontForTiles.

	self addMorphBack: label.
	self addMorphBack: turtleTile.
