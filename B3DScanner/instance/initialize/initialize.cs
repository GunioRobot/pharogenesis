initialize
	aet _ B3DActiveEdgeTable new.
	fillList _ B3DFillList new.
	added _ B3DPrimitiveEdgeList new.
	lastIntersection _ B3DPrimitiveEdge new.
	nextIntersection _ B3DPrimitiveEdge new.
	objects _ OrderedCollection new.