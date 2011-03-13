testDecompilerInClassesINtoIZ
	self decompileClassesSelect: [:cn| cn first = $I and: [cn second asUppercase > $M]]