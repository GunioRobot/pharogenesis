methodReturnTop
	| last |
	last _ stack removeLast.
	stack size > blockStackBase  "get effect of elided pop before return"
		ifTrue: [statements addLast: stack removeLast].
	exit _ method size + 1.
	lastJumpPc _ lastReturnPc _ lastPc.
	statements addLast: last