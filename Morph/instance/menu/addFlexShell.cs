addFlexShell
	"Wrap a rotating and scaling shell around this morph."

	| oldHalo flexMorph anActorState aName |
	self isFlexMorph ifTrue: [^ self].
	oldHalo _ self halo.

	self owner addMorph:
		(flexMorph _ TransformationMorph new asFlexOf: self).

	(anActorState _ self valueOfProperty: #actorState) ifNotNil:
		[flexMorph setProperty: #actorState toValue: anActorState.
		self removeProperty: #actorState].

	(aName _ self valueOfProperty: #name) ifNotNil:
		[flexMorph setProperty: #name toValue: aName.
		self removeProperty: #name].

	costumee ifNotNil:
		[flexMorph costumee: costumee.
		costumee rawCostume: flexMorph].

	oldHalo ifNotNil: [oldHalo setTarget: flexMorph]
