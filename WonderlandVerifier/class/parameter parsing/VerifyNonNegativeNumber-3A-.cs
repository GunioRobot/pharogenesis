VerifyNonNegativeNumber: parameter
	"If the parameter is a valid number this method returns true, otherwise it throws an exception"

	((parameter isNumber) and: [ parameter >= 0 ])
			ifTrue: [ ^ true ]
			ifFalse: [ self error: (parameter asString) , ' is not a number greater than or equal to zero. ' ].
