xSecondExtendedSend
	"	10000110		send argCount=xx selectorIndex=yyyyyy
		xxyyyyyy

	=>	SingleExtendedSend
		nArgs
		nil
		selector"

	"Note: see also xDoubleExtendedDoAnything"

	| descriptor |
	descriptor _ self nextByte.
	self emitOp: SingleExtendedSend.
	self emitInteger: ((descriptor >> 6) bitAnd: 3).		"arg count"
	self emitSkip: 1.
	self emitLiteralSelector: (descriptor bitAnd: 63 "selector index").