doOneSubCycleFor: aWorld
	"Like doOneCycle, but preserves activeHand."

	| currentHand |
	currentHand _ ActiveHand.
	self doOneCycleFor: aWorld.
	ActiveHand _ currentHand