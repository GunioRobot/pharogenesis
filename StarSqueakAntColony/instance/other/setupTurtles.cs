setupTurtles

	self makeTurtles: antCount class: AntColonyTurtle.
	turtles do: [:t |
		t goto: 50@50.
		t color: Color black.
		t isCarryingFood: false.
		t pheromoneDropSize: 100].
