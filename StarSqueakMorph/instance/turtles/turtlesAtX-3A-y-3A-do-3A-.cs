turtlesAtX: x y: y do: aBlock 
	"Evaluate the given block for each turtle at the given location."

	| t |
	t := self firstTurtleAtX: x y: y.
	[t isNil] whileFalse: 
			[aBlock value: t.
			t := t nextTurtle]