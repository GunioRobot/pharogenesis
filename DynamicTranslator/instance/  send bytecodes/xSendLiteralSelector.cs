xSendLiteralSelector
	"	11xxyyyy	sendLiteralSelector yyyy with {illegal 0 1 2}[xx] args

	=>	SendLiteralSelector{0,1,2,3}
		selector"

	"Note: see also xDoubleExtendedDoAnything"

	| nArgs |
	nArgs _ (((currentByte >> 4) bitAnd: 3) - 1).
	nArgs = 0	ifTrue: [self emitOp: SendLiteralSelector0]	ifFalse: [
	nArgs = 1	ifTrue: [self emitOp: SendLiteralSelector1]		ifFalse: [
	nArgs = 2	ifTrue: [self emitOp: SendLiteralSelector2]	]].
	self emitLiteralSelector: (currentByte bitAnd: 15).