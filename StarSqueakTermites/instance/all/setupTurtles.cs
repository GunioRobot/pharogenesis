setupTurtles
	"Create an initialize my termites."

	self makeTurtles: 400 class: TermiteTurtle.
	self turtlesDo: [:t | t isCarryingChip: false].
