replicateTurtle: aTurtle
	"Create an exact copy of the given turtle and add it to this world."

	| newTurtle |
	newTurtle _ aTurtle clone who: (lastTurtleID _ lastTurtleID + 1).
	turtles _ turtles copyWith: newTurtle.
