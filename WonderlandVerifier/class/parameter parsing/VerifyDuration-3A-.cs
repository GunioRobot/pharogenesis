VerifyDuration: parameter
	"If the parameter is a valid duration this method returns true, otherwise it throws an exception"

	((( parameter = rightNow) or: [ parameter = eachFrame ])
		or: [ (parameter isNumber) and: [ parameter >= 0 ]	])
					ifTrue: [ ^ true ]
					ifFalse: [ self error: (parameter asString) , ' is not a valid duration. ' ].
