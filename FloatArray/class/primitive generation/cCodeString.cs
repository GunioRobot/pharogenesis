cCodeString
	"FloatArray cCodeString"
	^PluggableCodeGenerator new codeStringForPrimitives:#(
		(FloatArray primAddArray:withArray:from:to:)
		(FloatArray primSubArray:withArray:from:to:)
		(FloatArray primMulArray:withArray:from:to:)
	)