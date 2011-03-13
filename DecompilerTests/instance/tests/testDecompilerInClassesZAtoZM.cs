testDecompilerInClassesZAtoZM
	self decompileClassesSelect: [:cn| cn first = $Z and: [cn second asUppercase <= $M]]