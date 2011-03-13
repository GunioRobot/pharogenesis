veryDeepCopyWithoutCostumee
	"Note: Ted's veryDeepCopy should be in Morph, not in Object"

	| hold copy holdState |
	hold _ costumee.
	holdState _ self valueOfProperty: #actorState.
	holdState ifNotNil: [self removeProperty: #actorState].
	costumee _ nil.
	copy _ self veryDeepCopy.
	holdState ifNotNil:
		[copy setProperty: #actorState toValue: (holdState copyWithPlayerReferenceNilled)].
	costumee _ hold.
	holdState ifNotNil: [self setProperty: #actorState toValue: holdState].
	^ copy