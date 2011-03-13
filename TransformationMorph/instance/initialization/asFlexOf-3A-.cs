asFlexOf: aMorph
	"Initialize me with position and bounds of aMorph,
	and with an offset that provides centered rotation."
	| pos |
	pos _ aMorph position.
	self addMorph: aMorph.
	aMorph position: (aMorph extent // 2) negated.
	self position: pos.
	transform _ transform withOffset: aMorph position - pos
