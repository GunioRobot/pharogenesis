newScaleFactor: newScaleFactor previousScaleFactor: oldScaleFactor
	"NB SketchMorph overrides."

	| ratio |
	ratio _ newScaleFactor asFloat / oldScaleFactor.
	self extent: ((ratio * self width) @ (ratio * self height)) rounded