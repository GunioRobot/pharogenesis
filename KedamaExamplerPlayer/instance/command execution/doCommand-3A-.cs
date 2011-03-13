doCommand: aBlock

	| ret |
	ret _ self doExamplerCommand: aBlock.
	turtles ifNotNil: [aBlock value: turtles].

	^ ret.
