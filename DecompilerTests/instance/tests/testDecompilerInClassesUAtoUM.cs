testDecompilerInClassesUAtoUM
	self decompileClassesSelect: [:cn| cn first = $U and: [cn second asUppercase <= $M]]