VerifyDimension: parameter
	"If the parameter is a valid dimension this method returns true, otherwise it throws an exception"

	(((parameter = leftToRight) or: [ parameter = topToBottom ]) or: [ parameter = frontToBack ])
			ifTrue: [ ^ true ]
			ifFalse: [ self error: (parameter asString) , ' is not a valid dimension. ' ].
