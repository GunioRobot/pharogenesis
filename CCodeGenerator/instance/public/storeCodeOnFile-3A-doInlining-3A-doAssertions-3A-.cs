storeCodeOnFile: fileName doInlining: inlineFlag doAssertions: assertionFlag
	"Store C code for this code base on the given file."

	| stream realName |
	"(self isTranslatingLocally and:[(fileName beginsWith: 'sq') not])
		ifTrue:[realName _ 'sq', fileName]
		ifFalse:[realName _ fileName]."
	stream _ CrLfFileStream newFileNamed: fileName.
	stream ifNil: [Error signal: 'Could not open C code file: ', realName].
	self emitCCodeOn: stream doInlining: inlineFlag doAssertions: assertionFlag.
	stream close