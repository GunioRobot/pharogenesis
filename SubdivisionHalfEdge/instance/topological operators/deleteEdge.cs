deleteEdge

	self spliceEdge: self originPrev.
	self symmetric spliceEdge: self symmetric originPrev.