pickUpFood

	| newFood |
	(isCarryingFood not and: [(self get: 'food') > 0]) ifTrue: [
		newFood := (self get: 'food') - 1.
		self set: 'food' to: newFood.
		newFood = 0 ifTrue: [self patchColor: world backgroundColor].
		isCarryingFood := true.
		pheromoneDropSize := 800.
		self color: Color red.

		"drop a blob of pheromone on the side of the food farthest from nest"
		self turnTowardsStrongest: 'nestScent'.
		self turnRight: 180.
		self forward: 4.
		self increment: 'pheromone' by: 5000].
