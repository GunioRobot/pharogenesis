connectEdge: edge
	"Add a new edge e connecting the destination of a to the
	origin of b, in such a way that all three have the same
	left face after the connection is complete.
	Additionally, the data pointers of the new edge are set."
	| e |
	e := self quadEdgeClass new.
	e first spliceEdge: self leftNext.
	e first symmetric spliceEdge: edge.
	(e first) origin: self destination; destination: edge origin.
	^e