doOneCycleInBackground
	"Do one cycle of the interactive loop. This method is called repeatedly when this world is not the active window but is running in the background."

	"process user input events, but only for remote hands"
	self handsDo: [:h |
		(h isKindOf: RemoteHandMorph) ifTrue: [
			self activeHand: h.
			h processEvents.
			self activeHand: nil]].

	self runStepMethods.
	self displayWorldSafely.
