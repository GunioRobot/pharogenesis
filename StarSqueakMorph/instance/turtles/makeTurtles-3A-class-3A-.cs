makeTurtles: count class: turtleClass
	"Create the given number of turtles of the given turtle class."

	turtles _ turtles,
		((1 to: count) collect: [:i |
			turtleClass new
				initializeWorld: self
				who: (lastTurtleID _ lastTurtleID + 1)]).
	self changed.
