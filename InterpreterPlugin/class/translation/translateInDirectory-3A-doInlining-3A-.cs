translateInDirectory: directory doInlining: inlineFlag
"This is the default method for writing out sources for a plugin. Several classes need special handling, so look at all implementors of this message"
	| cg fname fstat |
	 fname _ self moduleName, '.c'.

	"don't translate if the file is newer than my timeStamp"
	fstat _ directory entryAt: fname ifAbsent:[nil].
	fstat ifNotNil:[self timeStamp < fstat modificationTime ifTrue:[^nil]].

	self initialize.
	cg _ self buildCodeGeneratorUpTo: self.
	cg storeCodeOnFile:  (directory fullNameFor: fname) doInlining: inlineFlag.
	^cg exportedPrimitiveNames asArray