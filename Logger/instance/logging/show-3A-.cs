show: string
	stream notNil ifTrue:
		[stream nextPutAll: string.
		stream == Transcript ifTrue: [stream endEntry]]