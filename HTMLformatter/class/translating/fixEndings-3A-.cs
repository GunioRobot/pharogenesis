fixEndings: aStringOrStream
	| sourceStream targetStream aLine |
	(aStringOrStream isKindOf: Stream)
		ifTrue: [sourceStream := aStringOrStream]
		ifFalse: [sourceStream := ReadStream on: aStringOrStream].
	targetStream := ReadWriteStream on: String new. 
	[sourceStream atEnd] whileFalse:
	[aLine := sourceStream upTo: (Character linefeed).
	targetStream nextPutAll: aLine.
	targetStream nextPut: Character cr.].
	^targetStream
