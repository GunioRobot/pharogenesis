searchForFood
	"If you smell pheromone, go towards the strongest smell. Otherwise, wander aimlessly."

	isCarryingFood ifFalse: [
		((self get: 'pheromone') > 1)
			ifTrue: [self turnTowardsStrongest: 'pheromone']
			ifFalse: [
				self turnRight: (self random: 40).
				self turnLeft: (self random: 40)].
		self forward: 1].
