doOneCycleNow
	"Do one cycle of the interactive loop. This method is called repeatedly when the world is running."

	"process user input events"
	self handsDo: [:h |
		self activeHand: h.
		h processEvents.
		self activeHand: nil].

	self runStepMethods.
	self displayWorldSafely.
