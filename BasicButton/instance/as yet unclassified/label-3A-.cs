label: aString

	| oldLabel m |
	(oldLabel _ self findA: StringMorph)
		ifNotNil: [oldLabel delete].
	m _ StringMorph contents: aString font: TextStyle defaultFont.
	self extent: m extent + (borderWidth + 6).
	m position: self center - (m extent // 2).
	self addMorph: m.
	m lock