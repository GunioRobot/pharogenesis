display
	"Display this world on the Display. Used for debugging."

	| c |
	c _ FormCanvas extent: (dimensions * pixelsPerPatch) depth: 32.
	c _ c copyOffset: bounds origin negated.
	self drawOn: c.
	c form display.
