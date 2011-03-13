testDecompilerInClassesXAtoXM
	self decompileClassesSelect: [:cn| cn first = $X and: [cn second asUppercase <= $M]]