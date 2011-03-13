text 
	"Answer the receiver's string asText if remote files are enabled.
	Use a read only copy to avoid syntax errors when accessed via
	multiple processes."
	
	| theFile |
	(sourceFileNumber == nil or: [(SourceFiles at: sourceFileNumber) == nil]) ifTrue: [^ nil].
	theFile := (SourceFiles at: sourceFileNumber) readOnlyCopy.
	^[theFile position: filePositionHi.
	theFile position > theFile size ifTrue: [
		self error: 'RemoteString past end of file' ].
	theFile nextChunkText] ensure: [theFile close]