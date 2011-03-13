testDecompilerInClassesLAtoLM
	self decompileClassesSelect: [:cn| cn first = $L and: [cn second asUppercase <= $M]]