popUpForHand: hand in: aWorld
	| p |
	"Present this menu under control of the given hand."

	p _ hand position truncated.
	^self popUpAt: p forHand: hand in: aWorld
