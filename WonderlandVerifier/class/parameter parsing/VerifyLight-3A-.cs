VerifyLight: parameter
	"If the parameter is a valid type of light this method returns true, otherwise it throws an exception"

	((((parameter = ambient) or: [parameter = positional]) or: [parameter = directional])
			or: [parameter = spotlight])
		ifTrue: [ ^ true ]
		ifFalse: [ self error: (parameter asString) , ' is not a valid type of light. ' ].
