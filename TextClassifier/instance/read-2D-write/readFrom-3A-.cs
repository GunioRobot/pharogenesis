readFrom: aStream
	aStream atEnd ifTrue: [^ self reset].
	categorizer readFrom: aStream elementReader: [:s | s nextString].