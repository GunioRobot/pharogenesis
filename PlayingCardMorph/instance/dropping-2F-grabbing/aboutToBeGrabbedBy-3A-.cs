aboutToBeGrabbedBy: aHand
	"I'm about to be grabbed by the hand.  If other cards are above me in a deck,
	then move them from the deck to being submorphs of me"

	| i |
	i _ owner submorphs indexOf: self ifAbsent: [^ self].
	i = 1 ifTrue: [^ self].
	(owner submorphs copyFrom: 1 to: i-1) do:
		[:m | m class = self class ifTrue: [self addMorphBack: m]].

