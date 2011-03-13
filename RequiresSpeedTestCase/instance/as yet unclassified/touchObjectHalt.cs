touchObjectHalt
	^Object compile: (Object sourceCodeAt: #halt ifAbsent: []) asString