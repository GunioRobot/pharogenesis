testDecompilerInClassesHNtoHZ
	self decompileClassesSelect: [:cn| cn first = $H and: [cn second asUppercase > $M]]