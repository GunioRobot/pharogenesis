addLabel

	| m |
	self isThisEverCalled.
	self removeAllMorphs.
	m _ StringMorph new contents: 'Trash'.
	self extent: (m width + 6) @ (m height + 10).
	m position: self center - (m extent // 2).
	self addMorph: m.
	m lock
