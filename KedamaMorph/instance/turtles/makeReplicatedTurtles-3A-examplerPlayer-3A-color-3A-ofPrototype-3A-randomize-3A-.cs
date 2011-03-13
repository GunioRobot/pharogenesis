makeReplicatedTurtles: count examplerPlayer: tp color: c ofPrototype: prototype randomize: randomizeFlag

	| array inst |
	array _ tp turtles.

	inst _ prototype ifNil: [self makePrototypeOfExampler: tp color: c].

	turtlesDictSemaphore critical: [
		array addTurtlesCount: count ofPrototype: inst for: self randomize: randomizeFlag.
	].
	self calcTurtlesCount.
	self changed.
