testDecompilerInClassesFAtoFM
	self decompileClassesSelect: [:cn| cn first = $F and: [cn second asUppercase <= $M]]