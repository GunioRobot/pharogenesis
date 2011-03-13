doOneSubCycleFor: aWorld
	"Like doOneCycle, but preserves activeHand."

	| currentHand |
	currentHand _ activeHand.
	self doOneCycleFor: aWorld.
	activeHand _ currentHand