grabMorph: m
	"Grab the given morph (i.e., add it to this hand and remove it from its current owner) without changing its position. This is used to pick up a morph under the hand's current position, versus attachMorph: which is used to pick up a morph that may not be near this hand."

	| morphToGrab editor |
	formerOwner _ m owner.
	formerPosition _ m position.
	m isTileLike ifTrue:
		[editor _ m topEditor].

	(m owner isKindOf: DropShadowMorph)
		ifTrue:
			[self grabMorph: m owner]
		ifFalse:
			[morphToGrab _ self world morphToGrabFrom: m.
			morphToGrab == m ifFalse: [m delete].
			gridOn ifTrue: [m position: (m position grid: grid)].
			self addMorphBack: morphToGrab].

	editor ifNotNil: [editor scriptEdited]