extendByHand: aHand
	"Assumes selection has just been created and added to some pasteUp or world"
	| startPoint handle |
	startPoint _ self position.
	handle _ NewHandleMorph new followHand: aHand
		forEachPointDo: [:newPoint | self bounds: (startPoint rect: newPoint)]
		lastPointDo: [:newPoint | selectedItems isEmpty ifTrue: [self delete]
												ifFalse: [self doneExtending]].
	aHand attachMorph: handle.
	handle startStepping.