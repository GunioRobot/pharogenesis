globalIncomingQueue

	^GlobalIncomingQueue ifNil: [GlobalIncomingQueue _ OrderedCollection new].