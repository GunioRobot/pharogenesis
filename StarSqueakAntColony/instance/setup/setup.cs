setup

	self clearAll.
	self setupPatches.
	self setupTurtles.
	turtleDemons _ #(searchForFood pickUpFood returnToNest dropFoodInNest).
	worldDemons _ #(evaporatePheromone diffusePheromone).
