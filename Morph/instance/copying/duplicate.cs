duplicate
	"Make and return a duplicate of the receiver"

	| newMorph aName w aPlayer topRend |
	((topRend _ self topRendererOrSelf) ~~ self) ifTrue: [^ topRend duplicate].

	self okayToDuplicate ifFalse: [^ self].
	aName _ (w _ self world) ifNotNil:
		[w nameForCopyIfAlreadyNamed: self].
	newMorph _ self veryDeepCopy.
	aName ifNotNil: [newMorph setNameTo: aName].

	newMorph arrangeToStartStepping.
	newMorph privateOwner: nil. "no longer in world"
	newMorph isPartsDonor: false. "no longer parts donor"
	(aPlayer _ newMorph player) belongsToUniClass ifTrue:
		[aPlayer class bringScriptsUpToDate].
	aPlayer ifNotNil: [ActiveWorld presenter flushPlayerListCache].
	^ newMorph