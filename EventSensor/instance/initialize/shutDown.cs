shutDown
	inputProcess ifNotNil:[inputProcess terminate].
	inputProcess _ nil.
	inputSemaphore ifNotNil:[Smalltalk unregisterExternalObject: inputSemaphore].