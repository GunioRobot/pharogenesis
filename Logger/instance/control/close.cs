close
	(stream notNil and: [stream ~~ Transcript])
		ifTrue: [stream close].
	stream _ nil.