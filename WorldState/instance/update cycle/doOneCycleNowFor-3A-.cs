doOneCycleNowFor: aWorld
	"Immediately do one cycle of the interaction loop.
	This should not be called directly, but only via doOneCycleFor:"

	| capturingGesture |
	DisplayScreen checkForNewScreenSize.
	capturingGesture _ false.
	self flag: #bob.		"need to consider remote hands in lower worlds"

	"process user input events"
	LastCycleTime _ Time millisecondClockValue.
	self handsDo: [:h |
		ActiveHand _ h.
		h processEvents.
		capturingGesture _ capturingGesture or: [ h isCapturingGesturePoints ].
		ActiveHand _ nil
	].

	"the default is the primary hand"
	ActiveHand _ self hands first.

	"The gesture recognizer needs enough points to be accurate.
	Therefore morph stepping is disabled while capturing points for the recognizer"
	capturingGesture ifFalse: 
		[aWorld runStepMethods.		"there are currently some variations here"
		self displayWorldSafely: aWorld].
