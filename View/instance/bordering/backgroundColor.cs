backgroundColor
	insideColor == nil ifFalse:
		[(insideColor isMemberOf: Symbol) ifTrue:
			[^ Color perform: insideColor].
		^ insideColor].
	superView == nil ifFalse: [^ superView backgroundColor].
	^ Display white