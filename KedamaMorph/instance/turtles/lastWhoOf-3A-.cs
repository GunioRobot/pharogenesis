lastWhoOf: exampler

	| turtles |
	turtles _ turtlesDict at: exampler ifAbsent: [nil].
	^ (turtles arrays first) at: turtles arrays first size.
