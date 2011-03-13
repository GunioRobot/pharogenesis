usableDuplicate
	|  aName usedNames newPlayer newMorph |

	newMorph _ self fullCopy.

	costumee ifNotNil:
		[newPlayer _ costumee duplicatedPlayerForCostume: newMorph.
			"nb newPlayer has had his costume set to newMorph in the above-called method"
		self isFlexMorph ifTrue: [newMorph renderedMorph costumee: newPlayer]. "???"
		newMorph actorState: (costumee actorState shallowCopy initializeFor: newPlayer)].

	(aName _ self knownName) == nil ifTrue:
		[costumee ~~ nil ifTrue: [aName _ newMorph innocuousName]].  "Force a difference here"
	aName ~~ nil ifTrue:
		[usedNames _ self world allKnownNames copyWith: aName.
		newMorph setNameTo: (Utilities keyLike: aName satisfying: [:f | (usedNames includes: f) not])].
	newMorph justDuplicatedFrom: self.
	newMorph removeProperty: #partsDonor.
	newMorph privateOwner: nil.
	(newPlayer ~~ nil and: [newMorph renderedMorph eventHandler ~~ nil]) ifTrue:
		[newPlayer assureEventHandlerRepresentsStatus].
	newPlayer ifNotNil: [self world flushPlayerListCache].

	^ newMorph