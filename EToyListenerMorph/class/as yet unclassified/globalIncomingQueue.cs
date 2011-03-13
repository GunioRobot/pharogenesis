globalIncomingQueue

	^GlobalIncomingQueue ifNil: [GlobalIncomingQueue := OrderedCollection new].