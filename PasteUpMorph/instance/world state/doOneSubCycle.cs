doOneSubCycle
	"Like doOneCycle, but preserves activeHand."

	| currentHand |
	currentHand _ self activeHand.
	self interCyclePause: MinCycleLapse.
	self doOneCycleNow.
	self activeHand: currentHand