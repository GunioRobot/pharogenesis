copySourceTo: aFileStream
	"Copy the source code for the receiver to aFileStream. Answer true if there are no 
	problems, false if no files specified in the global SourceFiles or position is zero."
	| position |
	(SourceFiles at: self fileIndex) == nil ifTrue: [^false].
	Cursor read
		showWhile: 
			[position _ self filePosition.
			position ~= 0
				ifTrue: [(SourceFiles at: self fileIndex) position: position;
							copyChunkTo: aFileStream]].
	^position ~= 0