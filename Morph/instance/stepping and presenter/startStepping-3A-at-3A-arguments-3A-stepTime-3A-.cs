startStepping: aSelector at: scheduledTime arguments: args stepTime: stepTime
	"Start stepping the receiver"
	| w |
	w _ self world.
	w ifNotNil: [
		w startStepping: self at: scheduledTime selector: aSelector arguments: args stepTime: stepTime.
		self changed].