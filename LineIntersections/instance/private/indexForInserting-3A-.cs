indexForInserting: aPoint
	"Return the appropriate index for inserting the given x value"
	| index low high side |
	low _ 1.
	high _ activeEdges size.
	[index _ (high + low) bitShift: -1.
	low > high] whileFalse:[
		side _ (activeEdges at: index) sideOfPoint: aPoint.
		side = 0 ifTrue:[^index].
		side > 0
			ifTrue:[high _ index - 1]
			ifFalse:[low _ index + 1]].
	^low