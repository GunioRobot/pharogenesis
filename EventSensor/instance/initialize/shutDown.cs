shutDown
	super shutDown.
	EventTicklerProcess ifNotNil: [
		EventTicklerProcess terminate.
		EventTicklerProcess _ nil. ].
	inputSemaphore ifNotNil:[Smalltalk unregisterExternalObject: inputSemaphore].
