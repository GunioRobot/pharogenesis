testDecompilerInClassesAAtoAM
	self decompileClassesSelect: [:cn| cn first = $A and: [cn second asUppercase <= $M]]