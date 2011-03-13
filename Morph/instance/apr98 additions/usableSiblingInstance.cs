usableSiblingInstance
	|  aName usedNames newPlayer newMorph |

	newMorph _ self fullCopy.
	newPlayer _ costumee class new costume: newMorph.
	self isFlexMorph ifTrue: [newMorph renderedMorph costumee: newPlayer]. "???"
	newMorph actorState: (costumee actorState shallowCopy initializeFor: newPlayer).

	(aName _ self knownName) == nil ifTrue:
		[costumee ~~ nil ifTrue: [aName _ newMorph innocuousName]].  "Force a difference here"
	aName ~~ nil ifTrue:
		[usedNames _ self world allKnownNames copyWith: aName.
		newMorph setNameTo: (Utilities keyLike: aName satisfying: [:f | (usedNames includes: f) not])].
	"newMorph justDuplicatedFrom: self.  NOT done for sibling inst"
	newMorph privateOwner: nil.
	(newMorph renderedMorph eventHandler ~~ nil) ifTrue:
		[newPlayer assureEventHandlerRepresentsStatus].
	self world flushPlayerListCache.

	^ newMorph