removeAt: index
	"Remove the element at given position"
	(index < 1 or:[index > tally]) ifTrue:[^self errorSubscriptBounds: index].
	^self privateRemoveAt: index