testDecompilerInClassesENtoEZ
	self decompileClassesSelect: [:cn| cn first = $E and: [cn second asUppercase > $M]]