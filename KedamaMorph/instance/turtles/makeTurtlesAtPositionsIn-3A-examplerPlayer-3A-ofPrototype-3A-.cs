makeTurtlesAtPositionsIn: positionAndColorArray examplerPlayer: tp ofPrototype: prototype

	| array inst |
	array _ tp turtles.

	inst _ prototype ifNil: [self makePrototypeOfExampler: tp].

	turtlesDictSemaphore critical: [array addTurtlesCount: positionAndColorArray first size ofPrototype: inst for: self positionAndColorArray: positionAndColorArray].
	self calcTurtlesCount.
	self changed.
