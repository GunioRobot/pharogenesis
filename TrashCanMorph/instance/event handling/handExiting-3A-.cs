handExiting: aHand
	"Set by step when the given hand exits me."

	((aHand submorphCount > 0) and:
	 [aHand submorphs first ~~ self])
		ifTrue: [
			self world soundsEnabled ifTrue: [self class playMouseLeaveSound].
			aHand endDisplaySuppression.
			self state: #off]
		ifFalse: [
			self stopShowingStampIn: aHand].
