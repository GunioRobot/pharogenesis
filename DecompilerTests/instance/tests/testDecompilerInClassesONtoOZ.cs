testDecompilerInClassesONtoOZ
	self decompileClassesSelect: [:cn| cn first = $O and: [cn second asUppercase > $M]]