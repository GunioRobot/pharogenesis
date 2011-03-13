addPaneVSplitters

	| remaining targetX sameX |
	remaining _ paneMorphs copy reject: [:each | each layoutFrame rightFraction = 1].
	[remaining notEmpty] whileTrue:
		[targetX _ remaining first layoutFrame rightFraction.
		sameX _ paneMorphs select: [:each | each layoutFrame rightFraction = targetX].
		self addPaneVSplitterBetween: remaining first and: sameX.
		remaining _ remaining copyWithoutAll: sameX]