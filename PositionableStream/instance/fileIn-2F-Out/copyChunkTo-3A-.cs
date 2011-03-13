copyChunkTo: aWriteStream
	"Copy the next chunk onto aWriteStream (must be different from the receiver).  If HTML, bold the selector in a cheating way. 
	4/11/96 tk"
	| terminator text parser where start sel |
	terminator _ $!.
	self skipSeparators.
	start _ self position.
	sel _ self upTo: Character cr.
	self position: start.
	text _ self upTo: terminator.
	text size < sel size 
		ifTrue: ["oops! no cr"
			aWriteStream nextPutAll: text; nextPut: terminator]
		ifFalse: ["bold the method header"
			aWriteStream command: 'b'.
			aWriteStream nextPutAll: sel.
			aWriteStream command: '/b'.
			aWriteStream nextPutAll: 
				(text copyFrom: sel size + 1 to: text size).
			aWriteStream nextPut: terminator].
	[self peekFor: terminator] whileTrue:   "case of imbedded (doubled) terminator"
			[aWriteStream nextPut: terminator;
				nextPutAll: (self upTo: terminator);
				nextPut: terminator].