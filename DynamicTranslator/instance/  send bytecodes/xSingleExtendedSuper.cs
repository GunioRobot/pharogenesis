xSingleExtendedSuper
	"	10000101		super send argCount=xxx selectorIndex=yyyyy
		xxxyyyyy

	=>	SingleExtendedSuper
		nArgs
		nil
		selector"

	"Note: see also xDoubleExtendedDoAnything"

	| descriptor |
	descriptor _ self nextByte.
	self emitOp: SingleExtendedSuper.
	self emitInteger: (descriptor >> 5).		"arg count"
	self emitSkip: 1.
	self emitLiteralSelector: (descriptor bitAnd: 31 "selector index").