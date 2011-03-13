getReplicated

	| newGuys theNewGuy |
	newGuys _ world makeTurtles: 1 turtlePlayerClass: self class color: self color ofPrototype: self.
	theNewGuy _ newGuys first.
	theNewGuy x: self x.
	theNewGuy y: self y.
	theNewGuy heading: self heading.
	(world prototypeOf: self class) privateTurtleCount: (world turtlesCountOf: self class).
	^ theNewGuy
