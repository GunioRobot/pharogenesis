rShiftTable
	| theTable |
	self returnTypeC:'int *'.
	self inline: false. "Don't you inline this!!!"
	self var:#theTable declareC:'static int theTable[17] =
		{0, 5, 4, 0, 3, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 1}'.
	^theTable