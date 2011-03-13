string 
	"Answer the receiver's string if remote files are enabled.
	Use a read only copy to avoid syntax errors when accessed via
	multiple processes."
	
	| theFile |
	(sourceFileNumber == nil or: [(SourceFiles at: sourceFileNumber) == nil]) ifTrue: [^''].
	theFile := (SourceFiles at: sourceFileNumber) readOnlyCopy.
	^[theFile position: filePositionHi.
	theFile nextChunk] ensure: [theFile close]