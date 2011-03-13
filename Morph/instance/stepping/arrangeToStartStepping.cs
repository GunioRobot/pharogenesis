arrangeToStartStepping
	"Arrange to start getting sent the 'step' message, but don't do that initial #step call that startStepping does"

	| w |
	w _ self world.
	w ifNotNil:
		[w startStepping: self.
		self changed]