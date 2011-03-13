recognizeAndDispatch: charDispatchBlock until: terminationBlock
	"Recognize characters, and dispatch each one found by evaluating charDispatchBlock; proceed until terminationBlock is true. 9/18/96 sw"

	^ self recognizeAndDispatch: charDispatchBlock
		ifUnrecognized: 
			[:features | self stringForUnrecognizedFeatures: features]
		until: terminationBlock
 