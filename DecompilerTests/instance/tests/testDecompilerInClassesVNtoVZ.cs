testDecompilerInClassesVNtoVZ
	self decompileClassesSelect: [:cn| cn first = $V and: [cn second asUppercase > $M]]