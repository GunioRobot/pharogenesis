loadDateFrom: aStream
	"Load the creation date from the first chunk."

	^Compiler evaluate: aStream nextChunk
