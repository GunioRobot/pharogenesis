simpleProcess: aStringOrStream
	| sourceStream targetStream ch |
	(aStringOrStream isKindOf: Stream)
		ifTrue: [sourceStream := aStringOrStream]
		ifFalse: [sourceStream := ReadStream on: aStringOrStream].
	targetStream := WriteStream on: String new. 
	[sourceStream atEnd] whileFalse:
	[ch := sourceStream next.
	(ch = Character linefeed) ifTrue:
		[(sourceStream peek) = (Character linefeed)
		ifTrue: [sourceStream next. targetStream nextPutAll: '<p>']
		ifFalse: [targetStream nextPutAll: '<br>']].
	targetStream nextPut: ch].
	^targetStream contents.
