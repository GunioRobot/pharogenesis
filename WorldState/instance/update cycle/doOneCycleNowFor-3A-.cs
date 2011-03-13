doOneCycleNowFor: aWorld
	"Do one cycle of the interactive loop. This method is called repeatedly when the world is running."

	self flag: #bob.		"need to consider remote hands in lower worlds"
	"process user input events"
	LastCycleTime _ Time millisecondClockValue.
	self handsDo: [:h |
		activeHand _ h.
		h processEvents.
		activeHand _ nil
	].

	aWorld runStepMethods.		"there are currently some variations here"
	self displayWorldSafely: aWorld.
