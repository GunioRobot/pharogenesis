insertEdgeIntoAET: edge
	"Insert the edge with the given index from the global edge table into the active edge table.
	The edge has already been stepped to the initial yValue -- thus remainingLines and rasterX
	are both set."
	| index |
	self inline: false.

	"Check for the number of lines remaining"
	(self edgeNumLinesOf: edge) <= 0 ifTrue:[^nil]. "Nothing to do"

	"Find insertion point"
	index _ self indexForInsertingIntoAET: edge.

	"And insert edge"
	self insertToAET: edge beforeIndex: index.