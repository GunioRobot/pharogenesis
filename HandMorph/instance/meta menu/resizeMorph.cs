resizeMorph
	| handle minExtent |
	argument isAlignmentMorph
		ifTrue: [minExtent _ argument minWidth @ argument minHeight]
		ifFalse: [minExtent _ 1@1].
	handle _ HandleMorph new forEachPointDo:
		[:newPoint | argument extent: ((newPoint - argument bounds topLeft)
										max: minExtent)].
	self attachMorph: handle.
	handle startStepping.
