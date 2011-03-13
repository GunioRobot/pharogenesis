runStepMethodsIn: aWorld
	"Perform periodic activity inbetween event cycles"
	| queue numItems i limit stamp |

	queue _ self class deferredUIMessages.
	numItems _ queue size.
	i _ 0.
	limit _ self class deferredExecutionTimeLimit.
	stamp _ Time millisecondClockValue.

	"Dispatch deferred messages while maintaing rudimentary UI responsiveness."
	[i < numItems and: [(Time millisecondsSince: stamp) < limit]]
		whileTrue: [queue next value. i _ i + 1].

	self runLocalStepMethodsIn: aWorld.

	"we are using a normal #step for these now"
	"aWorld allLowerWorldsDo: [ :each | each runLocalStepMethods ]."
