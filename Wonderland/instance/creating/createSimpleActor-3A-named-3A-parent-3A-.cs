createSimpleActor: aMesh named: aString parent: parentActor
	| newActor |
	newActor _ self makeActorNamed: aString.
	aMesh ifNotNil:[newActor setMesh: aMesh].
	parentActor ifNotNil:[
		newActor reparentTo: parentActor.
		newActor becomePart].
	^newActor