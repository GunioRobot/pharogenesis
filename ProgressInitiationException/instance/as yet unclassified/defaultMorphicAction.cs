defaultMorphicAction
	| t1 t2 |
	t1 := SystemProgressMorph
				label: progressTitle
				min: minVal
				max: maxVal.
	[t2 := workBlock value: t1]
		ensure: [SystemProgressMorph close: t1].
	self resume: t2