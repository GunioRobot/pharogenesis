resortFirst
	"Resort the first entry in the active edge table"
	| edge xValue leftEdge newIndex |
	start = 1 ifTrue:[^self]. "Nothing to do"
	"Fetch the edge to test."
	edge _ array at: start.
	xValue _ edge xValue.
	"Fetch the next edge left to it."
	leftEdge _ array at: start-1.
	leftEdge xValue <= xValue ifTrue:[^self]. "Okay."
	"Move the edge left to its correct insertion point."
	newIndex _ start.
	[newIndex > 1 and:[(leftEdge _ array at: newIndex-1) xValue > xValue]]
		whileTrue:[	array at: newIndex put: leftEdge.
					newIndex _ newIndex - 1].
	array at: newIndex put: edge.