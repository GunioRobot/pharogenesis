compilerClass
	^ (Smalltalk at: name ifAbsent: [^ Compiler]) compilerClass