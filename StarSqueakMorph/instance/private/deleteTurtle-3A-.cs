deleteTurtle: aTurtle
	"Delete the given turtle from this world."

	turtles := turtles copyWithout: aTurtle.
