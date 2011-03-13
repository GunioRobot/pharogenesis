handEntering: aHand
	"Set by step when the given hand enters me."

	((aHand submorphCount > 0) and:
	 [aHand submorphs first ~~ self])
		ifTrue: [
			self world soundsEnabled ifTrue: [self class playMouseEnterSound].
			aHand startDisplaySuppression.
			self world abandonAllHalos.
			self state: #pressed]
		ifFalse: [
			self showStampIn: aHand].
