followPheromone
	"If I smell pheromone, turn in the direction that it gets stronger. Otherwise, turn a random amount right or left. In either case, move forward one step."

	((self get: 'pheromone') > 60)
		ifTrue: [self turnTowardsStrongest: 'pheromone']
		ifFalse: [
			self turnRight: (self random: 45).
			self turnLeft: (self random: 45)].
	self forward: 1.
