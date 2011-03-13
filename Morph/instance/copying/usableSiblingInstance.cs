usableSiblingInstance
	"Return another similar morph whose Player is of the same class as mine"

	|  aName usedNames newPlayer newMorph topRenderer |
	self flag: #noteToTed.  "I think this may have deviated majorly from your mainstream veryDeepCopy work, so there will probably be some problems entailed"
	(topRenderer _ self topRendererOrSelf) == self ifFalse: [^ topRenderer usableSiblingInstance].

	self player assureUniClass.
	newMorph _ self veryDeepCopyWithoutPlayer.
	newPlayer _ self player class new costume: newMorph.
	newPlayer copyAddedStateFrom: self player.
	newPlayer resetCostumeList.
	self isFlexMorph ifTrue: [newMorph renderedMorph player: newPlayer]. "???"
	newMorph actorState: (self player actorState shallowCopy initializeFor: newPlayer).

	(aName _ self knownName) == nil ifTrue:
		[self player ~~ nil ifTrue: [aName _ newMorph innocuousName]].
			"Force a difference here"
	aName ~~ nil ifTrue:
		[usedNames _ (self world ifNil: [OrderedCollection new] ifNotNil: [self world allKnownNames]) copyWith: aName.
		newMorph setNameTo: (Utilities keyLike: aName satisfying: [:f | (usedNames includes: f) not])].
	newMorph privateOwner: nil.
	(newMorph renderedMorph eventHandler ~~ nil) ifTrue:
		[newPlayer assureEventHandlerRepresentsStatus].
	self currentWorld addMorphBack: newMorph.

	self presenter flushPlayerListCache.

	^ newMorph