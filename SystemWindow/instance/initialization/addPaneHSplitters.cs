addPaneHSplitters

	| remaining targetY sameY |
	remaining _ paneMorphs copy reject: [:each | each layoutFrame bottomFraction = 1].
	[remaining notEmpty] whileTrue:
		[targetY _ remaining first layoutFrame bottomFraction.
		sameY _ paneMorphs select: [:each | each layoutFrame bottomFraction = targetY].
		self addPaneHSplitterBetween: remaining first and: sameY.
		remaining _ remaining copyWithoutAll: sameY]