duplicateMorph
	| newMorph aName usedNames |
	newMorph _ argument veryDeepCopy.
	(aName _ argument knownName) ~~ nil ifTrue:
		[usedNames _ self world allKnownNames copyWith: aName.
		newMorph setNameTo:
			(Utilities keyLike: aName satisfying: [:f | (usedNames includes: f) not])].

	self grabMorphFromMenu: newMorph.
	formerPosition _ argument position.
	newMorph player ifNotNil: [newMorph player startRunning].
	^ newMorph