defaultMorphicAction
	| result progress |
	progress _ SystemProgressMorph label: progressTitle min: minVal max: maxVal.
	[result _ workBlock value: progress] ensure: [SystemProgressMorph close: progress].
	self resume: result