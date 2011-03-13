duplicate
	"Make and return a duplicate of the receiver"

	| newMorph aName w topRend |
	((topRend := self topRendererOrSelf) ~~ self) ifTrue: [^ topRend duplicate].

	self okayToDuplicate ifFalse: [^ self].
	aName := (w := self world) ifNotNil:
		[w nameForCopyIfAlreadyNamed: self].
	newMorph := self veryDeepCopy.
	aName ifNotNil: [newMorph setNameTo: aName].

	newMorph arrangeToStartStepping.
	newMorph privateOwner: nil. "no longer in world"
	newMorph isPartsDonor: false. "no longer parts donor"
	^ newMorph