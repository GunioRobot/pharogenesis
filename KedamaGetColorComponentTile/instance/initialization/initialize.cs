initialize

	super initialize.
	type _ #Patch.
	operatorOrExpression _ #getBlueComponentIn:.
	self addPatchTile.
	self line1: 'getBlueComponentIn:'.
