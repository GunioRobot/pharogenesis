Verify0To1Number: parameter
	"If the parameter is a valid number this method returns true, otherwise it throws an exception"

	(((parameter isNumber) and: [ parameter >= 0 ]) and: [ parameter <= 1 ])
					ifTrue: [ ^ true ]
					ifFalse: [ self error: (parameter asString) , ' is not a number between 0 and 1. ' ].
