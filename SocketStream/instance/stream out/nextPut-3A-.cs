nextPut: char
	self outStream nextPut: (self isBinary ifTrue: [char asInteger] ifFalse: [char asCharacter]).
	self checkFlush