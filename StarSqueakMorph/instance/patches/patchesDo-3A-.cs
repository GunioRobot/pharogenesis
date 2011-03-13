patchesDo: aBlock
	"Evaluate the given block for every patch in this world."

	| patch |
	patch := StarSqueakPatch new world: self.
	0 to: dimensions y - 1 do: [:y |
		patch y: y.
		0 to: dimensions x - 1 do: [:x |
			patch x: x.
			aBlock value: patch]].
