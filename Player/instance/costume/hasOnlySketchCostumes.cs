hasOnlySketchCostumes
	"Answer true if the only costumes assocaited with this Player are SketchMorph costumes"

	(costume renderedMorph isKindOf: SketchMorph) ifFalse: [^ false].
	costumes ifNotNil: [costumes do:
		[:cost | (cost isKindOf: SketchMorph) ifFalse: [^ false]]].
	^ true