createLabels
	| numeral font h r |
	self removeAllMorphs.
	font _ StrikeFont familyName: fontName size: (h _ self height min: self width)//8.
	r _ 1.0 - (1.4 * font height / h).
	1 to: 12 do:
		[:hour |
		numeral _ romanNumerals
			ifTrue: [hour printStringRoman]
			ifFalse: [hour asString].
		self addMorphBack: ((StringMorph contents: numeral font: font emphasis: 1)
			center: (self radius: r hourAngle: hour)) lock]