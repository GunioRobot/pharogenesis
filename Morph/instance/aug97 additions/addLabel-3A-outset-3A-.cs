addLabel: aString outset: aPoint

	| m |
	self removeAllMorphs.
	m _ StringMorph new contents: aString.
	self extent: (m width + aPoint x) @ (m height + aPoint y).
	m position: self center - (m extent // 2).
	self addMorph: m.
