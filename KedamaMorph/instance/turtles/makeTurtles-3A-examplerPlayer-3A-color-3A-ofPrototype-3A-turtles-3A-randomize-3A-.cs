makeTurtles: count examplerPlayer: tp color: c ofPrototype: prototype turtles: turtles randomize: randomizeFlag

	| array inst |
	array _ tp turtles.
	(turtlesDict keys includes: tp) ifFalse: [
		self addToTurtleDisplayList: tp.
		turtlesDict at: tp put: (array _ turtles).
	].

	inst _ prototype ifNil: [self makePrototypeOfExampler: tp color: c].

	turtlesDictSemaphore critical: [array setTurtlesCount: count prototype: inst for: self randomize: randomizeFlag].
	self calcTurtlesCount.
	self changed.
