testDecompilerInClassesGNtoGZ
	self decompileClassesSelect: [:cn| cn first = $G and: [cn second asUppercase > $M]]