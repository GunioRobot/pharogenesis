fixForIE: text
	| ch targetStream sourceStream |
	targetStream := WriteStream on: String new.
	sourceStream := ReadStream on: text.
	[sourceStream atEnd] whileFalse:
	[ch := sourceStream next.
	ch = $> ifTrue: [targetStream nextPutAll: '&gt;']
	ifFalse: [ch = $< ifTrue: [targetStream nextPutAll: '&lt;']
		ifFalse: [targetStream nextPut: ch]].].
	^targetStream contents
