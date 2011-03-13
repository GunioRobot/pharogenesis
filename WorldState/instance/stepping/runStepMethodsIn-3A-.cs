runStepMethodsIn: aWorld
	"Perform periodic activity inbetween event cycles"
	| queue |

	queue _ self class deferredUIMessages.
	[queue isEmpty] whileFalse: [
		queue next value
	].
	self runLocalStepMethodsIn: aWorld.

	"we are using a normal #step for these now"
	"aWorld allLowerWorldsDo: [ :each | each runLocalStepMethods ]."
