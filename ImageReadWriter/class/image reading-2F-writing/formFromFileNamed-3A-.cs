formFromFileNamed: fileName
	"Answer a ColorForm stored on the file with the given name."
	| stream |
	stream _ FileStream readOnlyFileNamed: fileName.
	^self formFromStream: stream