initialize

	super initialize.
	type _ #Patch.
	operatorOrExpression _ #setBlueComponentIn:to:.
	self addPatchTile.
	self line1: 'setBlueComponent:'.
