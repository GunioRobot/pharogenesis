testDecompilerInClassesQAtoQM
	self decompileClassesSelect: [:cn| cn first = $Q and: [cn second asUppercase <= $M]]