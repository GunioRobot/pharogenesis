makeTurtles: count examplerPlayer: tp color: c ofPrototype: prototype turtles: turtles randomize: randomizeFlag

	| array inst |
	array := tp turtles.
	(turtlesDict keys includes: tp) ifFalse: [
		self addToTurtleDisplayList: tp.
		turtlesDict at: tp put: (array := turtles).
	].

	inst := prototype ifNil: [self makePrototypeOfExampler: tp color: c].

	turtlesDictSemaphore critical: [array setTurtlesCount: count prototype: inst for: self randomize: randomizeFlag].
	self calcTurtlesCount.
	self changed.
