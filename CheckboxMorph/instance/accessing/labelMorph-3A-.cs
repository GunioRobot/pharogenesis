labelMorph: aMorph
	"Set the value of labelMorph"

	labelMorph ifNotNil: [labelMorph delete].
	labelMorph := aMorph.
	self addMorphBack: aMorph