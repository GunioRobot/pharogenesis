sourceFileStream 
	"Answer the sources file stream with position set at the beginning of my source string"

	| pos |
	(pos _ self filePosition) = 0 ifTrue: [^ nil].
	^ (RemoteString newFileNumber: self fileIndex position: pos) fileStream