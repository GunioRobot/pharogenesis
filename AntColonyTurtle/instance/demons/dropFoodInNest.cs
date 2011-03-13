dropFoodInNest

	(isCarryingFood and: [(self get: 'isNest') > 0]) ifTrue: [
		self color: Color black.
		isCarryingFood := false.
		"turn around and go forward to try to pick up pheromone trail"
		self turnRight: 180.
		self forward: 3].
