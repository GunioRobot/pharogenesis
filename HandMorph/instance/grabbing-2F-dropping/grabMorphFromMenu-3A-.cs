grabMorphFromMenu: m
	"Grab the given morph (i.e., add it to this hand and remove it from its current owner) without changing its position. This is used to pick up a morph under the hand's current position, versus attachMorph: which is used to pick up a morph that may not be near this hand."
	| delta |
	(m owner isKindOf: DropShadowMorph)
		ifTrue: [^ self grabMorphFromMenu: m owner].
	delta _ m position - menuTargetOffset.
	gridOn ifTrue: [delta _ delta grid: grid].
	m position: self position + delta.
	self addMorphBack: m.