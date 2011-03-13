makeTurtles: count class: turtleClass
	"Create the given number of turtles of the given turtle class."

	turtles := turtles,
		((1 to: count) collect: [:i |
			turtleClass new
				initializeWorld: self
				who: (lastTurtleID := lastTurtleID + 1)]).
	self changed.
