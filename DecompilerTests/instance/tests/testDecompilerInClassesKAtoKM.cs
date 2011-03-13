testDecompilerInClassesKAtoKM
	self decompileClassesSelect: [:cn| cn first = $K and: [cn second asUppercase <= $M]]