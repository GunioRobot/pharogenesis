booleanCheat: cond

	| bytecode offset |
	self inline: true.

	bytecode _ self fetchByte.  "assume next bytecode is jumpIfFalse (99%)"
	self internalPop: 2.
	(bytecode < 160 and: [bytecode > 151]) ifTrue: [  "short jumpIfFalse"
		cond
			ifTrue: [^ self fetchNextBytecode]
			ifFalse: [^ self jump: bytecode - 151]].

	bytecode = 172 ifTrue: [  "long jumpIfFalse"
		offset _ self fetchByte.
		cond
			ifTrue: [^ self fetchNextBytecode]
			ifFalse: [^ self jump: offset]].

	"not followed by a jumpIfFalse; undo instruction fetch and push boolean result"
	localIP _ localIP - 1.
	self fetchNextBytecode.
	cond
		ifTrue: [self internalPush: trueObj]
		ifFalse: [self internalPush: falseObj].
