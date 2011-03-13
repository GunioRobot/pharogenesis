returnToNest

	isCarryingFood ifTrue: [
		"decrease size of pheromone drops to create a gradient back to food"
		pheromoneDropSize > 0 ifTrue: [
			self increment: 'pheromone' by: pheromoneDropSize.
			pheromoneDropSize := pheromoneDropSize - 20].
		self turnTowardsStrongest: 'nestScent'.
		self forward: 1].
