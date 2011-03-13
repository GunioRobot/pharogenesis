label: aString font: aFontOrNil

	| oldLabel m aFont |
	(oldLabel _ self findA: StringMorph)
		ifNotNil: [oldLabel delete].
	(oldLabel _ self findA: TextMorph)
		ifNotNil: [oldLabel delete].
	aFont _ aFontOrNil ifNil: [Preferences standardButtonFont].
	m _ TextMorph new contents: aString; beAllFont: aFont.
	self extent: (m width + 6) @ (m height + 6).
	m position: self center - (m extent // 2).
	self addMorph: m.
	m lock
