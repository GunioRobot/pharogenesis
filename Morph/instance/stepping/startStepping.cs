startStepping
	"Start getting sent the 'step' message."

	| w |
	self step.  "one to get started!"
	w _ self world.
	w ifNotNil: [
		w startStepping: self.
		self changed].