computeHeight
	^self isLeaf
		ifTrue:[height _ 0]
		ifFalse:[height _ (left computeHeight max: right computeHeight) + 1].