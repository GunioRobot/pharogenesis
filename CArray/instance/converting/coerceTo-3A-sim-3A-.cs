coerceTo: cTypeString sim: interpreterSimulator

	cTypeString = 'int' ifTrue: [^ self ptrAddress].
	cTypeString = 'unsigned' ifTrue: [^ self ptrAddress].
	^ self