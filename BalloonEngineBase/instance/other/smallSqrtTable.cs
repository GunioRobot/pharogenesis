smallSqrtTable
	| theTable |
	self inline: false.
	self returnTypeC:'int *'.
	self var: #theTable declareC:'static int theTable[32] = 
	{0, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 6}'.
	^theTable