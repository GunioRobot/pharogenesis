swapEdge
	"Essentially turns edge e counterclockwise inside its enclosing
	quadrilateral. The data pointers are modified accordingly."

	| a b |
	a := self originPrev.
	b := self symmetric originPrev.
	self spliceEdge: a.
	self symmetric spliceEdge: b.
	self spliceEdge: a leftNext.
	self symmetric spliceEdge: b leftNext.
	self origin: a destination; destination: b destination.