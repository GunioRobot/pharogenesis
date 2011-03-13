setGreenComponentIn: aPatch to: value

	| i pix |
	i _ self index.
	pix _ aPatch costume renderedMorph pixelAtX: ((turtles arrays at: 2) at: i) y: ((turtles arrays at: 3) at: i).
	pix _ (pix bitAnd: 16rFF00FF) bitOr: ((value asInteger bitAnd: 16rFF) bitShift: 8).
	aPatch costume renderedMorph pixelAtX: ((turtles arrays at: 2) at: i) y: ((turtles arrays at: 3) at: i) put: pix.
