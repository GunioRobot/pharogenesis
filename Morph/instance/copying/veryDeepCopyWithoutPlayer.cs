veryDeepCopyWithoutPlayer
	"Make a very deep copy of the receiver but do not include its player in it -- obliterate it wherever it occurs, then make the very deep copy, then restore it where needed in the original"

	| hold copy holdState renderedMorph playerOfRenderedMorph |
	hold _ self player.
	holdState _ self actorStateOrNil.
	holdState ifNotNil: [self actorState: nil].
	(renderedMorph _ self renderedMorph) ~~ self
		ifTrue: [playerOfRenderedMorph _ renderedMorph player.
				renderedMorph player: nil.]
		ifFalse:	[nil].
	self player: nil.
	copy _ self veryDeepCopy.
		"My player should not be there, and the formerOwner thing should no longer be
		a problem owing to Andreas's recent fixes for that"
	holdState ifNotNil:
		[copy actorState: (holdState copyWithPlayerReferenceNilled)].
	self player: hold.
	playerOfRenderedMorph ifNotNil: [renderedMorph player: playerOfRenderedMorph].
	holdState ifNotNil: [self actorState: holdState].
	^ copy