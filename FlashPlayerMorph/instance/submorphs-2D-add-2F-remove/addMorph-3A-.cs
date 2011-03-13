addMorph: aMorph
	aMorph isFlashMorph ifFalse:[^super addMorph: aMorph].
	aMorph isMouseSensitive
		ifTrue:[self addMorphFront: aMorph]
		ifFalse:[self addMorphBack: aMorph].