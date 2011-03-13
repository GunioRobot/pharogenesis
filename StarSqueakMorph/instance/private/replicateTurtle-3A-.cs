replicateTurtle: aTurtle
	"Create an exact copy of the given turtle and add it to this world."

	| newTurtle |
	newTurtle := aTurtle clone who: (lastTurtleID := lastTurtleID + 1).
	turtles := turtles copyWith: newTurtle.
