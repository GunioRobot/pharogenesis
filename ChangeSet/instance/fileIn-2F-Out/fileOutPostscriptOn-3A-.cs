fileOutPostscriptOn: stream 
	"If the receiver has a postscript, put it out onto the stream.  "

	| aString |
	aString _ self postscriptString.
	(aString ~~ nil and: [aString size > 0])
		ifTrue:
			[stream nextChunkPut: aString "surroundedBySingleQuotes".
			stream cr; cr]