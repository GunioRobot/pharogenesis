bounce

	(self turtleCountHere > 1) ifTrue: [
		self turnRight: 180 + (self random: 45).
		self turnLeft: (self random: 45)].
