turtlesDo: aBlock
	"Evaluate the given block for every turtle. For example:
		w turtlesDo: [:t | t forward: 1]
	will tell every turtle to go forward by one turtle step."

	turtles do: aBlock.
	self changed.
