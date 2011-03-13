defaultAction
	| result progress |
	progress := SystemProgressMorph label: progressTitle min: minVal max: maxVal.
	[result := workBlock value: progress] ensure: [SystemProgressMorph close: progress].
	self resume: result