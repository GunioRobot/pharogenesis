VerifyPoint: parameter
	"If the parameter is a valid point this method returns true, otherwise it throws an exception"

	(parameter isKindOf: Point)
		ifTrue: [ ^ true ]
		ifFalse: [ self error: (parameter asString) , ' is not a valid point. ' ].
