digits: aNumber

	digits _ aNumber.
	self removeAllMorphs.
	1 to: digits do: [:i | self addMorph: (LedDigitMorph new color: color)].
	self layoutChanged.
	self changed.