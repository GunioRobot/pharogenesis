usableSiblingInstance
	|  aName usedNames newPlayer newMorph |
	self flag: #noteToTed.  "Note I've fallen back on veryDeepCopyWithoutPlayer here, because I want another instance of my Player's class rather than a new Player subclass."

	newMorph _ self veryDeepCopyWithoutPlayer.
	newPlayer _ self player class new costume: newMorph.
	self isFlexMorph ifTrue: [newMorph renderedMorph player: newPlayer]. "???"
	newMorph actorState: (self player actorState shallowCopy initializeFor: newPlayer).

	(aName _ self knownName) == nil ifTrue:
		[self player ~~ nil ifTrue: [aName _ newMorph innocuousName]].
			"Force a difference here"
	aName ~~ nil ifTrue:
		[usedNames _ self world allKnownNames copyWith: aName.
		newMorph setNameTo: (Utilities keyLike: aName satisfying: [:f | (usedNames includes: f) not])].
	"newMorph justDuplicatedFrom: self.  NOT done for sibling inst"
	newMorph privateOwner: nil.
	(newMorph renderedMorph eventHandler ~~ nil) ifTrue:
		[newPlayer assureEventHandlerRepresentsStatus].
	self presenter flushPlayerListCache.

	^ newMorph