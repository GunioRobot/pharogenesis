foregroundColor
	borderColor == nil ifFalse:
		[(borderColor isMemberOf: Symbol) ifTrue:
			[^ Color perform: borderColor].
		^ borderColor].
	superView == nil ifFalse: [^ superView foregroundColor].
	^ Color black