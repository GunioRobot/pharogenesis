rootForGrabOf: aMorph
	"Allow submorph to be extracted."

	| m outerPhrase tt |
	self inPartsBin ifTrue: [^ super rootForGrabOf: aMorph].
	self isSticky ifTrue: [^ nil].
	outerPhrase _ self.
	m _ self owner.
	[m == nil] whileFalse:
		[(m isKindOf: PhraseTileMorph) ifTrue: [outerPhrase _ m].
		m _ m owner].
	(tt _ self topEditor) ifNotNil: [tt markEdited].
	^ outerPhrase
