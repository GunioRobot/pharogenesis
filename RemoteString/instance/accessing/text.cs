text 
	"Answer the receiver's string asText if remote files are enabled."
	| theFile |
	(sourceFileNumber == nil or: [(SourceFiles at: sourceFileNumber) == nil]) ifTrue: [^ nil].
	theFile _ SourceFiles at: sourceFileNumber.
	theFile position: filePositionHi.
	theFile position > theFile size ifTrue: [
		self error: 'RemoteString past end of file' ].
	^ theFile nextChunkText