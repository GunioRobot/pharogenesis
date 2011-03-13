testDecompilerInClassesDNtoDZ
	self decompileClassesSelect: [:cn| cn first = $D and: [cn second asUppercase > $M]]