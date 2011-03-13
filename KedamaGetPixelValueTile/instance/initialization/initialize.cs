initialize

	super initialize.
	type _ #Patch.
	operatorOrExpression _ #getPatchValueIn:.
	self addPatchTile.
	self line1: 'getPatchValueIn:'.
