getSource
	"Answer the source code for the receiver. Answer nil if there are no 
	source files specified in the global SourceFiles."
	| source position |
	(SourceFiles at: self fileIndex) == nil ifTrue: [^nil].
	Cursor read
		showWhile: 
			[position _ self filePosition.
			position = 0
				ifTrue: [source _ nil]
				ifFalse: [source _ (RemoteString newFileNumber: self fileIndex
												position: position) string]].
	^source