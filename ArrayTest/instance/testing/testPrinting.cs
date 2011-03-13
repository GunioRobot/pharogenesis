testPrinting
	self assert: literalArray printString = '#(1 true 3 #four)'.
	self assert: (literalArray = (Compiler evaluate: literalArray printString)).
	"self assert: selfEvaluatingArray printString =  '{1. true. (3/4). Color black. (2 to: 4). 5}'."
	self assert: (selfEvaluatingArray = (Compiler evaluate: selfEvaluatingArray printString)).
	self assert: nonSEArray1 printString =  'an Array(1 a Set(1))'.
	self assert: nonSEarray2 printString =  '{#Array->Array}'
