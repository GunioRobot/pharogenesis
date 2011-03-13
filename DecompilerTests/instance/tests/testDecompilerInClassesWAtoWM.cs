testDecompilerInClassesWAtoWM
	self decompileClassesSelect: [:cn| cn first = $W and: [cn second asUppercase <= $M]]