backgroundColor
	Display depth <= 2 ifTrue: [^ Color white].
	insideColor == nil ifFalse:
		[(insideColor isMemberOf: Symbol) ifTrue:
			[^ Color perform: insideColor].
		^ insideColor].
	superView == nil ifFalse: [^ superView backgroundColor].
	^ Color white