runStepMethodsIn: aWorld
	"Perform periodic activity inbetween event cycles"
	| queue nextInQueue|

	"If available dispatch some deferred UI Message"
	queue := self class deferredUIMessages.
	nextInQueue := queue nextOrNil.
	nextInQueue ifNotNil: [ nextInQueue value].

	self runLocalStepMethodsIn: aWorld.