startEdgeEvent: evt
	| idx edge evtPoint index keepChecking other side |
	edge _ evt segment.
	Debug == true ifTrue:[self debugDrawLine: edge color: Color blue].
	evtPoint _ evt position.
	"Find left-most insertion point"
	idx _ self firstIndexForInserting: evtPoint.
	index _ idx.
	keepChecking _ true.
	"Check all edges containing the same insertion point"
	[idx <= activeEdges size
		ifTrue:[	other _ activeEdges at: idx.
				side _ other sideOfPoint: evtPoint]
		ifFalse:[side _ -1].
	side = 0] whileTrue:[
		idx _ idx + 1.
		self recordIntersection: edge with: other at: evtPoint.
		"Check edges as long as we haven't found the insertion index"
		keepChecking ifTrue:[
			(self isLeft: other direction comparedTo: edge direction)
				ifTrue:[index _ index + 1]
				ifFalse:[keepChecking _ false]].
	].
	activeEdges add: edge afterIndex: index-1.
	self computeIntersectionAt: index-1 belowOrRightOf: evtPoint.
	self computeIntersectionAt: index belowOrRightOf: evtPoint.