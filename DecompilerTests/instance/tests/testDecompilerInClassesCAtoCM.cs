testDecompilerInClassesCAtoCM
	self decompileClassesSelect: [:cn| cn first = $C and: [cn second asUppercase <= $M]]