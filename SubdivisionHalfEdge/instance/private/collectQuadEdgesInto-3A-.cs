collectQuadEdgesInto: aSet

	(aSet includes: quadEdge) ifTrue:[^self].
	aSet add: quadEdge.
	self originNext collectQuadEdgesInto: aSet.
	self originPrev collectQuadEdgesInto: aSet.
	self destNext collectQuadEdgesInto: aSet.
	self destPrev collectQuadEdgesInto: aSet.
	^aSet