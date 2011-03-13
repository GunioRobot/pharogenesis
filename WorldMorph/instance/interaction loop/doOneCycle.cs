doOneCycle
	"Do one cycle of the interactive loop. This method is called repeatedly when the world is running."

	"process user input events"
	hands do: [:h |
		activeHand _ h.
		h processEvents.
		activeHand _ nil].

	self runStepMethods.
	self displayWorld.
