xSingleExtendedSend
	"	10000011		send argCount=xxx selectorIndex=yyyyy
		xxxyyyyy

	=>	SingleExtendedSend
		nArgs
		nil
		selector"

	"Note: see also xDoubleExtendedDoAnything"

	| descriptor |
	descriptor _ self nextByte.
	self emitOp: SingleExtendedSend.
	self emitInteger: (descriptor >> 5).		"arg count"
	self emitSkip: 1.
	self emitLiteralSelector: (descriptor bitAnd: 31 "selector index").