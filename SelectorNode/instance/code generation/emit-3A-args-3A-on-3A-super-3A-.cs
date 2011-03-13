emit: stack args: nArgs on: aStream super: supered
	| index |
	stack pop: nArgs.
	(supered not and: [code - Send < SendLimit and: [nArgs < 3]]) ifTrue:
		["short send"
		code < Send
			ifTrue: [^ aStream nextPut: code "special"]
			ifFalse: [^ aStream nextPut: nArgs * 16 + code]].
	index := code < 256 ifTrue: [code - Send] ifFalse: [code \\ 256].
	(index <= 31 and: [nArgs <= 7]) ifTrue: 
		["extended (2-byte) send [131 and 133]"
		aStream nextPut: SendLong + (supered ifTrue: [2] ifFalse: [0]).
		^ aStream nextPut: nArgs * 32 + index].
	(supered not and: [index <= 63 and: [nArgs <= 3]]) ifTrue:
		["new extended (2-byte) send [134]"
		aStream nextPut: SendLong2.
		^ aStream nextPut: nArgs * 64 + index].
	"long (3-byte) send"
	aStream nextPut: DblExtDoAll.
	aStream nextPut: nArgs + (supered ifTrue: [32] ifFalse: [0]).
	aStream nextPut: index