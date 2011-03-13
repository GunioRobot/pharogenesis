isOutput
	direction = #output ifTrue: [^ true].
	direction = #inputOutput ifTrue: [^ true].
	direction = #ioAsOutput ifTrue: [^ true].
	^ false