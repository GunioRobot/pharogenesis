resultType

	type == #literal ifTrue:
		[(literal isKindOf: Number) ifTrue: [^ #number].
		(literal isKindOf: String) ifTrue: [^ #string].
		(literal isKindOf: Point) ifTrue: [^ #point].
		(literal isKindOf: String) ifTrue: [^ #string].
		(literal isKindOf: Boolean) ifTrue: [^ #boolean].
		(literal isKindOf: Morph) ifTrue: [^ #costume]  "This last one dubious!"].

	type == #expression ifTrue:
		[^ #number].

	type == #objRef ifTrue: [^ #player].
	^ #unknown
