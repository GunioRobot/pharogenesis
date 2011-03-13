tryForNumStringsInNextArray
	"input numStringsInNextARray, if 4 bytes are available"

	self inBufSize >= 4 ifFalse: [^false].

	numStringsInNextArray := inBuf getInteger32: inBufIndex.
	"(numStringsInNextArray > 100 or: [numStringsInNextArray < 1]) ifTrue: [self barf]."
	inBufIndex := inBufIndex + 4.

	stringsForNextArray _ Array new: numStringsInNextArray.
	stringCounter _ 0.
	nextStringSize _ nil. 
	^true