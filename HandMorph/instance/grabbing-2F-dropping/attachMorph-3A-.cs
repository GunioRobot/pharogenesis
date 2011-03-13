attachMorph: m
	"Position the center of the given morph under this hand, then grab it. This method is used to grab far away or newly created morphs."
	| delta |
	delta _ m bounds extent // 2.
	gridOn ifTrue: [delta _ delta grid: grid].
	m position: self position - delta.
	self addMorphBack: m.