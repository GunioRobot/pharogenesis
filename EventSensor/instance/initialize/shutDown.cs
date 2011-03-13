shutDown
	super shutDown.
	EventTicklerProcess ifNotNil: [
		EventTicklerProcess terminate.
		EventTicklerProcess := nil. ].
	inputSemaphore ifNotNil:[Smalltalk unregisterExternalObject: inputSemaphore].
