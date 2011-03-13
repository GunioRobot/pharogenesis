testDecompilerInClassesYAtoYM
	self decompileClassesSelect: [:cn| cn first = $Y and: [cn second asUppercase <= $M]]