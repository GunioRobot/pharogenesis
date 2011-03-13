setPenDown: penDown
	"Set the penDown state as indicated, to true or false"

	| morph trailMorph tfm |
	self actorState setPenDown: penDown.
	((morph _ self costume) notNil and: [(trailMorph _ morph trailMorph) notNil])
		ifTrue:
		[tfm _ morph owner transformFrom: trailMorph.
		trailMorph notePenDown: penDown forPlayer: self
					at: (tfm localPointToGlobal: morph referencePosition)]
