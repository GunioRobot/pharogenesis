turnTowardsStrongest: patchVarName
	"Turn to point toward the nearby patch having the highest value of the given patch variable. This command uses only local information. In particular, it only considers patches within 'sniffRange' of this turtles location. For example, with the default 'sniffRange' of 1, it only considers the immediate neighbors of the patch this turtle is on."

	self heading: (world uphillOf: patchVarName forTurtle: self).
