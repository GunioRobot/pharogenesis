string
	"Answer the receiver's string if remote files are enabled."

	| theFile |
	(sourceFileNumber == nil or: [(SourceFiles at: sourceFileNumber) == nil])
		ifTrue: [^'']
		ifFalse: 
			[theFile _ SourceFiles at: sourceFileNumber.
			theFile position: (filePositionHi bitShift: 8) + filePositionLo.
			^theFile nextChunk]