oneStep
	"Perform one step of the StarSqueak world. Execute all turtle and world demons."

	"run demons in random order and increment the generation counter"

	| currentTurtles |
	turtleDemons notEmpty 
		ifTrue: 
			["Note: Make a copy of turtles list that won't change if turtles are created/deleted."

			currentTurtles := turtles copy.
			turtleDemons shuffled 
				do: [:sel | 1 to: currentTurtles size do: [:i | (currentTurtles at: i) perform: sel]]].
	worldDemons shuffled do: [:sel | self perform: sel].
	generation := generation + 1.
	turtlesAtPatchCacheValid := false