breakLoose
	"If I smell pheromone, turn in the direction that it gets stronger. Otherwise, turn a random amount right or left. In either case, move forward one step."

	((self random: 100) < 10) ifTrue: [
		self turnRight: (self random: 360).
		self forward: 3].
