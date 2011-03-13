testDecompilerInClassesJAtoJM
	self decompileClassesSelect: [:cn| cn first = $J and: [cn second asUppercase <= $M]]