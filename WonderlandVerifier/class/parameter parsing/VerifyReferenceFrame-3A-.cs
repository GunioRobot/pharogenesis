VerifyReferenceFrame: parameter
	"If the parameter is a valid WonderlandActor (or subclass) or WonderlandScene this method returns true, otherwise it throws an exception"

	((parameter isKindOf: WonderlandActor) or: [ parameter isKindOf: WonderlandScene])
		ifTrue: [ ^ true ]
		ifFalse: [ self error: (parameter asString) , ' does not have an orientation.' ].
