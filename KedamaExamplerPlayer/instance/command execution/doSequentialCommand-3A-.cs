doSequentialCommand: aBlock

	| ret |
	ret _ self doExamplerCommand: aBlock.
	self getGrouped ifFalse: [
		1 to: turtles size do: [:i |
			sequentialStub index: i.
			aBlock value: sequentialStub.
		].
	] ifTrue: [
		aBlock value: turtles.
	].
	turtles invalidateTurtleMap.
	^ ret.

