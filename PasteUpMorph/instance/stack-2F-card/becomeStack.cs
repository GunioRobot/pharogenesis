becomeStack
	currentDataInstance _ self assuredCostumee.
	dataInstances _ OrderedCollection with: currentDataInstance.
	isStackLike _ true.
	self borderWidth: (self borderWidth + 1).
	submorphs do:
		[:aMorph | aMorph holdsDataForEachInstance
			ifTrue:
				[aMorph becomeField]].