getPatchValueIn: aPatch

	| i |
	i := self index.
	^ aPatch costume renderedMorph pixelAtX: ((turtles arrays at: 2) at: i) y: ((turtles arrays at: 3) at: i).
