setup

	self clearAll.
	self makeTurtles: cellCount class: SlimeMoldTurtle.
	self createPatchVariable: 'pheromone'.  "emitted by slime mold cells"
	turtleDemons := #(dropPheromone followPheromone breakLoose).
	worldDemons := #(evaporatePheromone diffusePheromone).
	self displayPatchVariable: 'pheromone'.
