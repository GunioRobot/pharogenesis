testDecompilerInClassesBAtoBM
	self decompileClassesSelect: [:cn| cn first = $B and: [cn second asUppercase <= $M]]