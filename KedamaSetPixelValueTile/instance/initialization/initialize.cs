initialize

	super initialize.
	type _ #Patch.
	operatorOrExpression _ #setPatchValueIn:to:.
	self addPatchTile.
	self line1: 'setPatchValue:'.
