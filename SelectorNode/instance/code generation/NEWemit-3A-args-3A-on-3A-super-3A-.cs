NEWemit: stack args: nArgs on: aStream super: supered
	"This can be enabled when bytecode 134 has been redefined
	to be medium length send up to 64 lits"
	| index |
	stack pop: nArgs.
	(supered not and: [code - Send < SendLimit and: [nArgs < 3]])
		ifTrue: 
			["short send"
			aStream nextPut: 
					(code < Send
						ifTrue: [code]
						ifFalse: ["special" nArgs * 16 + code])]
		ifFalse: 
			[index _ code < 256 ifTrue: [code - Send]
								ifFalse: [code \\ 256].
			(index <= 31 and: [nArgs <= 7])
				ifTrue: 
					["medium send [131 and 133]"
					aStream nextPut: SendLong
									+ (supered ifTrue: [2] ifFalse: [0]).
					aStream nextPut: nArgs * 32 + index]
				ifFalse: 
					[(supered not and: [index <= 63 and: [nArgs <= 3]])
						ifTrue: 
							[" new medium send [134]"
							aStream nextPut: SendLong + 3.
							^ aStream nextPut: nArgs * 64 + index].
					"long send"
					aStream nextPut: SendLong + 1.
					aStream nextPut: nArgs
									+ (supered ifTrue: [32] ifFalse: [0]).
					aStream nextPut: index]]