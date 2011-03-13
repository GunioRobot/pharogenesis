resultType

	type == #literal ifTrue:
		[(literal isKindOf: Number) ifTrue: [^ #number]].
	type == #expression ifTrue:
		[^ #number].
	type == #objRef ifTrue: [^ #player].
	^ #unknown
