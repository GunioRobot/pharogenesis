bytecodeSize: bytecode
	| type lo |
	type _ bytecode // 16.
	type = 8
		ifTrue:
			[lo _ bytecode \\ 16.
			lo = 4 ifTrue: [^3].
			lo < 7 ifTrue: [^2]]
		ifFalse: [type = 10 ifTrue: [^2]].
	^1
