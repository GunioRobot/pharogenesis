registeredFlapsQuadsAt: aLabel
	"Answer the list of dynamic flaps quads at aLabel"

	^ (self registeredFlapsQuads at: aLabel)
		removeAllSuchThat: [:q | (self environment includesKey: q first) not or: [(self environment at: q first) isNil]]
