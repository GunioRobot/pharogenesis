getUphillIn: aPatch

	| i p |
	i _ self index.
	p _ aPatch costume renderedMorph.
	^ p
			uphillForTurtleX: ((turtles arrays at: 2) at: i)
			turtleY: ((turtles arrays at: 3) at: i)
			turtleHeading: ((turtles arrays at: 4) at: i).
