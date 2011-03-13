recordTurtlePositions
	"Record the current positions of all turtles (Actors) whose pens are down."

	| player |
	lastTurtlePositions _ IdentityDictionary new: submorphs size * 4.
	submorphs do: [:m |
		player _ m costumee.
		player ifNotNil: [
			player getPenDown ifTrue: [
				lastTurtlePositions at: player put: m referencePosition]]].
