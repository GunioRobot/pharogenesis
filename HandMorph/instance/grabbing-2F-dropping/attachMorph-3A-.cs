attachMorph: m
	"Position the center of the given morph under this hand, then grab it. This method is used to grab far away or newly created morphs."

	m position: self position - (m fullBounds extent // 2).
	self addMorphBack: m.
