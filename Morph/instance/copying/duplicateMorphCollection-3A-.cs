duplicateMorphCollection: aCollection
	"Make and return a duplicate of the receiver"

	| newCollection names |

	names _ aCollection collect: [ :ea | | newMorph w |
		(w _ ea world) ifNotNil:
			[w nameForCopyIfAlreadyNamed: ea].
	].

	newCollection _ aCollection veryDeepCopy.

	newCollection with: names do: [ :newMorph :name |
		name ifNotNil: [ newMorph setNameTo: name ].
		newMorph arrangeToStartStepping.
		newMorph privateOwner: nil. "no longer in world"
		newMorph isPartsDonor: false. "no longer parts donor"
	].

	^newCollection