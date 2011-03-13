testDecompilerInClassesPNtoPZ
	self decompileClassesSelect: [:cn| cn first = $P and: [cn second asUppercase > $M]]