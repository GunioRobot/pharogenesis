triangleEdges: timeStamp do: aBlock
	| e1 e2 e3 |
	"Evaluate aBlock with all edges making up triangles"
	quadEdge timeStamp = timeStamp ifTrue:[^self].
	quadEdge timeStamp: timeStamp.
	e1 _ self.
	e3 _ self originNext symmetric.
	e2 _ e3 originNext symmetric.
	(e2 timeStamp = timeStamp or:[e3 timeStamp = timeStamp])
		ifFalse:[aBlock value: e1 value: e2 value: e3].
	e1 _ self originPrev.
	e3 _ self symmetric.
	e2 _ e3 originNext symmetric.
	(e1 timeStamp = timeStamp or:[e2 timeStamp = timeStamp])
		ifFalse:[aBlock value: e1 value: e2 value: e3].
	self originNext triangleEdges: timeStamp do: aBlock.
	self originPrev triangleEdges: timeStamp do: aBlock.
	self destNext triangleEdges: timeStamp do: aBlock.
	self destPrev triangleEdges: timeStamp do: aBlock.