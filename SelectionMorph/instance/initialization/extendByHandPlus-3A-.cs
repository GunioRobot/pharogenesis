extendByHandPlus: aHand
	"Assumes selection has just been created and added to some pasteUp or world"
	| startPoint handle localPt |
	startPoint _ self position.
	handle _ NewHandleMorph new 
		followHand: aHand
		forEachPointDo: [ :newPoint | 
			localPt _ (self transformFrom: self world) globalPointToLocal: newPoint.
			self bounds: (startPoint rect: localPt)
		]
		lastPointDo: [ :newPoint | 
			selectedItems isEmpty ifTrue: [self delete] ifFalse: [self doneExtending]
		].
	aHand attachMorph: handle.
	handle startStepping.