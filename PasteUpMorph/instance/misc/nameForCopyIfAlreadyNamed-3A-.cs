nameForCopyIfAlreadyNamed: aMorph
	"Answer a name to set for a copy of aMorph if aMorph itself is named, else nil"

	| aName usedNames |
	^ (aName _ aMorph knownName) ifNotNil:
		[usedNames _ self allKnownNames.
		Utilities keyLike: aName satisfying: [:f | (usedNames includes: f) not]]