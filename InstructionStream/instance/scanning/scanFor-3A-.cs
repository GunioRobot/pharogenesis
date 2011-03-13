scanFor: scanBlock
	"Answer the index of the first bytecode for which scanBlock answer true
	 when supplied with that bytecode."

	| method end byte type |
	method := self method.
	end := method endPC.
	[pc <= end] whileTrue: 
		[(scanBlock value: (byte := method at: pc)) ifTrue:
			[^true].
		 type := byte // 16.
		 pc :=	type = 8 "extensions"
					ifTrue: [pc + (#(2 2 2 2 3 2 2 1 1 1 2 1 3 3 3 4) at: byte \\ 16 + 1)]
					ifFalse: [type = 10 "long jumps"
								ifTrue: [pc + 2]
								ifFalse: [pc + 1]]].
	^false