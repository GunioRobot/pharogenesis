doDieCommand: aBlock

	| ret origSize |
	ret _ self doExamplerCommand: aBlock.
	turtles initializeDeletingIndex.
	origSize _ turtles size.
	1 to: origSize do: [:i |
		i > origSize ifTrue: [^ ret].
		sequentialStub index: (turtles nextDeletingIndex).
		aBlock value: sequentialStub.
	].

	^ ret.

