donorActor: donorActor ownActor: ownActor
	(actualObject == donorActor) ifTrue: [actualObject _ ownActor].
	(type == #objRef and: [actualObject == ownActor])
		ifTrue:
			[self line1: actualObject externalName]
	