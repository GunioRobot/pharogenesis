storeCodeOnFile: fileName doInlining: inlineFlag doAssertions: assertionFlag
	"Store C code for this code base on the given file."

	| stream |
	stream _ CrLfFileStream forceNewFileNamed: fileName.
	stream ifNil: [Error signal: 'Could not open C code file: ', fileName].
	self emitCCodeOn: stream doInlining: inlineFlag doAssertions: assertionFlag.
	stream close