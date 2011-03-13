newMakeSetter: evt from: aMorph forPart: aSpec
	"Button in viewer performs this to make a new style tile and attach to hand."

	| m |
	m _ self newTilesFor: scriptedPlayer setter: aSpec.
	owner ifNotNil: [self primaryHand attachMorph: m.
			m align: m topLeft with: evt hand position + (7@14)]
		ifNil: [^ m].
