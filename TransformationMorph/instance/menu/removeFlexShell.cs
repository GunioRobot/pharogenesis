removeFlexShell
	"Remove the shell used to make a morph rotatable and scalable."

	| oldHalo unflexed anActorState aName |
	oldHalo _ self halo.
	submorphs isEmpty ifTrue: [^ self delete].
	unflexed _ self firstSubmorph.
	(anActorState _ self valueOfProperty: #actorState) ifNotNil:
		[unflexed setProperty: #actorState toValue: anActorState].
	(aName _ self valueOfProperty: #name) ifNotNil:
		[unflexed setProperty: #name toValue: aName].

	unflexed costumee: costumee.
	costumee ifNotNil:
		[costumee rawCostume: unflexed.
		costumee _ nil].
	self submorphs copy do: [:m |
		m position: self center - (m extent // 2).
		owner addMorph: m].
	oldHalo ifNotNil: [oldHalo setTarget: unflexed].
	self delete.
