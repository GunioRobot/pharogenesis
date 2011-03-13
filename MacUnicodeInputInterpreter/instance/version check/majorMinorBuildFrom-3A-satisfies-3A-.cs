majorMinorBuildFrom: aString satisfies: aBlock 
	| v |
	v := aString
				ifNil: [^ false].
	v := ((v copyAfter: $])
				findTokens: $ ) last findTokens: $..
	v size = 3
		ifFalse: [^ false].
	v := v
				collect: [:s | s initialIntegerOrNil
						ifNil: [^ false]].
	^ aBlock valueWithArguments: v asArray