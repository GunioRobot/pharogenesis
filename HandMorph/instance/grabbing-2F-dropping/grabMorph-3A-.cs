grabMorph: aMorph
	"Grab the given morph (i.e., add it to this hand and remove it from its current owner) without changing its position. This is used to pick up a morph under the hand's current position, versus attachMorph: which is used to pick up a morph that may not be near this hand."
	| editor localPt m trans morphToGrab pos |
	m _ aMorph.
	formerOwner _ m owner.
	formerPosition _ m position.
	m isTileLike ifTrue:
		[editor _ m topEditor].

	(m owner isKindOf: DropShadowMorph) ifTrue:
		[self grabMorph: m owner.
		^ editor ifNotNil: [editor scriptEdited]].

	"Check if the morph will keep it's transform while grabbed"
	m keepsTransform
		ifTrue:[localPt _ self position]
		ifFalse:[localPt _ m pointFromWorld: self position].

	m _ m aboutToBeGrabbedBy: self.
	m == nil ifTrue: [^ self].

	(formerOwner == nil
		or: [m keepsTransform
		or: [(trans _ formerOwner transformFromWorld) isPureTranslation]]) 
		ifTrue: [m position: self position + (m position - localPt).
				morphToGrab _ m.
				addedFlexAtGrab _ false]
		ifFalse: ["Morph was in a flexed environment.  Flex it in the hand."
				pos _ m position.
				morphToGrab _ m addFlexShell transform: trans asMorphicTransform.
				m position: pos.  "revert offset from addFlexShell"
				morphToGrab transform: (trans withOffset: (trans offset + (trans localPointToGlobal: pos + targetOffset) - self position)).
				addedFlexAtGrab _ true].

	gridOn ifTrue: [morphToGrab position: (morphToGrab position grid: grid)].
	self addMorphBack: morphToGrab.

	editor ifNotNil: [editor scriptEdited]