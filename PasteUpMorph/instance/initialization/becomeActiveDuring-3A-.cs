becomeActiveDuring: aBlock
	"Make the receiver the ActiveWorld during the evaluation of aBlock.
	Note that this method does deliberately *not* use #ensure: to prevent
	re-installation of the world on project switches."
	| priorWorld priorHand priorEvent |
	priorWorld _ ActiveWorld.
	priorHand _ ActiveHand.
	priorEvent _ ActiveEvent.
	ActiveWorld _ self.
	ActiveHand _ self hands first. "default"
	ActiveEvent _ nil. "not in event cycle"
	[aBlock value]
		on: Error
		do: [:ex | 
			ActiveWorld _ priorWorld.
			ActiveEvent _ priorEvent.
			ActiveHand _ priorHand.
			ex pass]