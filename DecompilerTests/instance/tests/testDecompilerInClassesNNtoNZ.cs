testDecompilerInClassesNNtoNZ
	self decompileClassesSelect: [:cn| cn first = $N and: [cn second asUppercase > $M]]