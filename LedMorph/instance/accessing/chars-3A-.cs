chars: aNumber 
	chars _ aNumber.
	self removeAllMorphs.
	1 to: chars do: [:i | self addMorph: (LedCharacterMorph new color: color)].
	self layoutChanged.
	self changed