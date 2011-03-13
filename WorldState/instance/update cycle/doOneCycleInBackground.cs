doOneCycleInBackground
	"Do one cycle of the interactive loop. This method is called repeatedly when this world is not the active window but is running in the background."

self halt.		"not ready for prime time"

	"process user input events, but only for remote hands"
	self handsDo: [:h |
		(h isKindOf: RemoteHandMorph) ifTrue: [
			activeHand _ h.
			h processEvents.
			activeHand _ nil]].

	self runStepMethods.
	self displayWorldSafely.
