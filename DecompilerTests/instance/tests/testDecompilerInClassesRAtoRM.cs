testDecompilerInClassesRAtoRM
	self decompileClassesSelect: [:cn| cn first = $R and: [cn second asUppercase <= $M]]