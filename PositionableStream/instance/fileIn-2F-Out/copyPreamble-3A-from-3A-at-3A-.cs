copyPreamble: preamble from: aStream at: pos
	"Look for a changeStamp for this method by peeking backward.
	Write a method preamble, with that stamp if found."
	| terminator methodPos p last50 stamp i |
	terminator _ $!.

	"Look back to find stamp in old preamble, such as...
	Polygon methodsFor: 'private' stamp: 'di 6/25/97 21:42' prior: 34957598! "
	aStream position: pos.
	methodPos _ aStream position.
	(aStream isMemberOf: MultiByteFileStream) ifTrue: [
		aStream position: (p _ 0 max: methodPos-100).
		last50 _ aStream basicNext: methodPos - p.
	] ifFalse: [
		aStream position: (p _ 0 max: methodPos-50).
		last50 _ aStream next: methodPos - p.
	].
	stamp _ String new.
	(i _ last50 findLastOccuranceOfString: 'stamp:' startingAt: 1) > 0 ifTrue:
		[stamp _ (last50 copyFrom: i+8 to: last50 size) copyUpTo: $'].

	"Write the new preamble, with old stamp if any."
	self cr; nextPut: terminator.
	self nextChunkPut: (String streamContents:
		[:strm |
		strm nextPutAll: preamble.
		stamp size > 0 ifTrue:
			[strm nextPutAll: ' stamp: '; print: stamp]]).
	self cr