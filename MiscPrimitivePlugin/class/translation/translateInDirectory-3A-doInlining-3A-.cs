translateInDirectory: directory doInlining: inlineFlag
"handle a special case code string rather than normal generated code."
	| cg fname fstat |
	 fname _ self moduleName, '.c'.

	"don't translate if the file is newer than my timeStamp"
	fstat _ directory entryAt: fname ifAbsent:[nil].
	fstat ifNotNil:[self timeStamp < fstat modificationTime ifTrue:[^nil]].

	self initialize.
	cg _ self buildCodeGeneratorUpTo: InterpreterPlugin.
	cg addMethodsForPrimitives: self translatedPrimitives.
	self storeString: cg generateCodeStringForPrimitives onFileNamed: (directory fullNameFor: fname).
	^cg exportedPrimitiveNames asArray
