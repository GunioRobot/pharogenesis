fileStream 
	"Answer the file stream with position set at the beginning of my string.
	Answer a read only copy to avoid syntax errors when accessed via
	multiple processes."

	| theFile |
	(sourceFileNumber == nil or: [(SourceFiles at: sourceFileNumber) == nil]) ifTrue: [^ nil].
	theFile := (SourceFiles at: sourceFileNumber) readOnlyCopy.
	theFile position: filePositionHi.
	^ theFile