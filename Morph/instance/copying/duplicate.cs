duplicate
	"Make and return a duplicate of the receiver"

	| newMorph aName w |
	self okayToDuplicate ifFalse: [^ self].
	aName _ (w _ self world) ifNotNil:
		[w nameForCopyIfAlreadyNamed: self].
	newMorph _ self veryDeepCopy.
	aName ifNotNil: [newMorph setNameTo: aName].

	newMorph arrangeToStartStepping.
	newMorph privateOwner: nil. "no longer in world"
	newMorph isPartsDonor: false. "no longer parts donor"
	^ newMorph