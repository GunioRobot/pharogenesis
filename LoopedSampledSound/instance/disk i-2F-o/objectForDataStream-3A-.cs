objectForDataStream: refStrm
    "Answer an object to store on a data stream, a copy of myself whose SampleBuffers have been converted into ByteArrays."

	| objToStore |
	objToStore _ self clone.
	objToStore leftSamples: leftSamples asByteArray.
	self isStereo
		ifTrue: [objToStore rightSamples: rightSamples asByteArray]
		ifFalse: [objToStore rightSamples: objToStore leftSamples].
	^ objToStore
