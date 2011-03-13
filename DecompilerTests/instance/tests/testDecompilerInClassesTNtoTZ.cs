testDecompilerInClassesTNtoTZ
	self decompileClassesSelect: [:cn| cn first = $T and: [cn second asUppercase > $M]]