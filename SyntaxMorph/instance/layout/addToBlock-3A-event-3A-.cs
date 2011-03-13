addToBlock: aMorph event: evt
	"Insert a new line of code"

	| whereDropped dropBefore |
	whereDropped _ "self pointFromWorld:" evt cursorPoint.
	dropBefore _ self submorphs 
		detect: [:each | each isSyntaxMorph and: [whereDropped y < each center y]] 
		ifNone: [nil].
	(aMorph nodeClassIs: ReturnNode) ifTrue: [dropBefore _ nil].
		"Returns are always at the end. (Watch out for comments)"

	dropBefore 
		ifNil: [self addMorphBack: aMorph]
		ifNotNil: [self addMorph: aMorph inFrontOf: dropBefore].
	self cleanupAfterItDroppedOnMe.
