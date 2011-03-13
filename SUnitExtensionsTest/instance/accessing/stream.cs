stream
	stream isNil ifTrue: [stream := WriteStream on: String new].
	^stream