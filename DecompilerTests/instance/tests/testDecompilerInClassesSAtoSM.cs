testDecompilerInClassesSAtoSM
	self decompileClassesSelect: [:cn| cn first = $S and: [cn second asUppercase <= $M]]