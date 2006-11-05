addPaneSplitters
	| splitter remaining target targetX sameX minY maxY targetY sameY minX maxX |
	self removePaneSplitters.
	self removeCornerGrips.

	remaining _ submorphs reject: [:each | each layoutFrame rightFraction = 1].
	[remaining notEmpty] whileTrue:
		[target _ remaining first.
		targetX _ target layoutFrame rightFraction.
		sameX _ submorphs select: [:each | each layoutFrame rightFraction = targetX].
		minY _ (sameX detectMin: [:each | each layoutFrame topFraction]) layoutFrame topFraction.
		maxY _ (sameX detectMax: [:each | each layoutFrame bottomFraction]) layoutFrame bottomFraction.
		splitter _ ProportionalSplitterMorph new.
		splitter layoutFrame: (LayoutFrame
			fractions: (targetX @ minY corner: targetX @ maxY)
			offsets: ((0 @ (target layoutFrame topOffset ifNil: [0]) corner: 4 @ (target layoutFrame bottomOffset ifNil: [0])) translateBy: (target layoutFrame rightOffset ifNil: [0]) @ 0)).
		self addMorphBack: (splitter position: self position).
		remaining _ remaining copyWithoutAll: sameX].

	remaining _ submorphs copy reject: [:each | each layoutFrame bottomFraction = 1].
	[remaining notEmpty]
		whileTrue: [target _ remaining first.
			targetY _ target layoutFrame bottomFraction.
			sameY _ submorphs select: [:each | each layoutFrame bottomFraction = targetY].
			minX _ (sameY detectMin: [:each | each layoutFrame leftFraction]) layoutFrame leftFraction.
			maxX _ (sameY detectMax: [:each | each layoutFrame rightFraction]) layoutFrame rightFraction.
			splitter _ ProportionalSplitterMorph new beSplitsTopAndBottom; yourself.
			splitter layoutFrame: (LayoutFrame
				fractions: (minX @ targetY corner: maxX @ targetY)
				offsets: (((target layoutFrame leftOffset ifNil: [0]) @ 0 corner: (target layoutFrame rightOffset ifNil: [0]) @ 4) translateBy: 0 @ (target layoutFrame bottomOffset ifNil: [0]))).
			self addMorphBack: (splitter position: self position).
			remaining _ remaining copyWithoutAll: sameY].

	self linkSubmorphsToSplitters.
	self splitters do: [:each | each comeToFront].
