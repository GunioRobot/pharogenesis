VerifyActor: parameter
	"If the parameter is a valid WonderlandActor (or subclass) this method returns true, otherwise it throws an exception"

	(parameter isKindOf: WonderlandActor)
		ifTrue: [ ^ true ]
		ifFalse: [ self error: (parameter asString) , ' is not a valid Wonderland Actor. ' ].
