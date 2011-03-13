popUpEvent: evt in: aWorld
	| h p |
	"Present this menu in response to the given event."

	h _ evt hand.
	p _ (aWorld pointFromWorld: h position) truncated.
	^self popUpAt: p forHand: h in: aWorld
