storeCodeOnFile: fileName doInlining: inlineFlag doAssertions: assertionFlag
	"Store C code for this code base on the given file."

	| stream |
	stream _ FileStream newFileNamed: fileName.
	self emitCCodeOn: stream doInlining: inlineFlag doAssertions: assertionFlag.
	stream close.