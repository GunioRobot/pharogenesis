text 
	"Answer the receiver's string asText if remote files are enabled."
	| theFile |
	(sourceFileNumber == nil or: [(SourceFiles at: sourceFileNumber) == nil]) ifTrue: [^ nil].
	theFile _ SourceFiles at: sourceFileNumber.
	theFile position: filePositionHi.
	^ theFile nextChunkText