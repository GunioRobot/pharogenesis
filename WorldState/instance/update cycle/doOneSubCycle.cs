doOneSubCycle
	"Like doOneCycle, but preserves activeHand."

	| currentHand |
	currentHand _ activeHand.
	self doOneCycle.
	activeHand _ currentHand