fileOutPreambleOn: stream 
	"If the receiver has a preamble, put it out onto the stream.  "

	| aString |
	aString _ self preambleString.
	(aString ~~ nil and: [aString size > 0])
		ifTrue:
			[stream nextChunkPut: aString "surroundedBySingleQuotes".
			stream cr; cr]