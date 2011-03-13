isOutputOnly
	direction = #output ifTrue: [^ true].
	direction = #ioAsOutput ifTrue: [^ true].
	^ false