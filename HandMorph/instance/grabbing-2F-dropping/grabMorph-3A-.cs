grabMorph: m
	"Grab the given morph (i.e., add it to this hand and remove it from its current owner) without changing its position. This is used to pick up a morph under the hand's current position, versus attachMorph: which is used to pick up a morph that may not be near this hand."

	(m owner isKindOf: DropShadowMorph)
		ifTrue: [self grabMorph: m owner]
		ifFalse: [self addMorphBack: m].
