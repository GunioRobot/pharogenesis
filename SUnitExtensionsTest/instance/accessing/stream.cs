stream
	stream isNil ifTrue: [stream := String new writeStream].
	^stream