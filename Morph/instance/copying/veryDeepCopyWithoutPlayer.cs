veryDeepCopyWithoutPlayer

	| hold copy holdState |
	hold _ self player.
	holdState _ self actorStateOrNil.
	holdState ifNotNil: [self actorState: nil].
	self player: nil.
	copy _ self veryDeepCopy.
	holdState ifNotNil:
		[copy actorState: (holdState copyWithPlayerReferenceNilled)].
	self player: hold.
	holdState ifNotNil: [self actorState: holdState].
	^ copy