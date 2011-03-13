setup

	self clearAll.
	self setupPatches.
	self setupTurtles.
	turtleDemons := #(searchForFood pickUpFood returnToNest dropFoodInNest).
	worldDemons := #(evaporatePheromone diffusePheromone).
