testDecompilerInClassesMAtoMM
	self decompileClassesSelect: [:cn| cn first = $M and: [cn second asUppercase <= $M]]