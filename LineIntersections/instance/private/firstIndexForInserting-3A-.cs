firstIndexForInserting: aPoint
	| index |
	index _ self indexForInserting: aPoint.
	[index > 1 and:[((activeEdges at: index-1) sideOfPoint: aPoint) = 0]]
		whileTrue:[index _ index-1].
	^index