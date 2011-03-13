isInput
	direction = #input ifTrue: [^ true].
	direction = #inputOutput ifTrue: [^ true].
	direction = #ioAsInput ifTrue: [^ true].
	^ false