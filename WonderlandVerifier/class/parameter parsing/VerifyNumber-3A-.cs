VerifyNumber: parameter
	"If the parameter is a valid number this method returns true, otherwise it throws an exception"

	(parameter isNumber)
					ifTrue: [ ^ true ]
					ifFalse: [ self error: (parameter asString) , ' is not a valid number. ' ].
