setup

	self clearAll.
	self makeTurtles: cellCount class: SlimeMoldTurtle.
	self createPatchVariable: 'pheromone'.  "emitted by slime mold cells"
	turtleDemons _ #(dropPheromone followPheromone breakLoose).
	worldDemons _ #(evaporatePheromone diffusePheromone).
	self displayPatchVariable: 'pheromone'.
