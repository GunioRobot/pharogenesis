scanPast: rangeType 
	"record rangeType for current token .
	record argument and temp declarations.
	scan and answer the next token"
	rangeType = #blockPatternArg ifTrue: [self pushArgument: currentToken].
	rangeType = #blockPatternTempVar ifTrue: [self pushTemporary: currentToken].
	rangeType = #patternArg ifTrue: [self pushArgument: currentToken].
	rangeType = #patternTempVar ifTrue: [self pushTemporary: currentToken].
	^self
		rangeType: rangeType;
		scanNext