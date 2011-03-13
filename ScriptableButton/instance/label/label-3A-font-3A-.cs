label: aString font: aFontOrNil
	"Set the receiver's label and font as indicated"

	| oldLabel m aFont |
	(oldLabel _ self findA: StringMorph)
		ifNotNil: [oldLabel delete].
	aFont _ aFontOrNil ifNil: [Preferences standardButtonFont].
	m _ StringMorph contents: aString font: aFont.
	self extent: (m width + 6) @ (m height + 6).
	m position: self center - (m extent // 2).
	self addMorph: m.
	m lock
