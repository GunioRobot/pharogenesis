deleteTurtle: aTurtle
	"Delete the given turtle from this world."

	turtles _ turtles copyWithout: aTurtle.
