setEdge: anEdge
	"Set the edge as indicated, if possible"

	| newOrientation e |
	e _ anEdge asSymbol.
	self edgeToAdhereTo = anEdge ifTrue: [^ self].
	newOrientation _ nil.
	self orientation == #vertical
		ifTrue: [(#top == e or: [#bottom == e]) ifTrue:
					[newOrientation _ #horizontal]]
		ifFalse: [(#top == e or: [#bottom == e]) ifFalse:
					[newOrientation _ #vertical]].
	self edgeToAdhereTo: e.
	newOrientation ifNotNil: [self transposeParts].
	referent isInWorld ifTrue: [self positionReferent].
	self adjustPositionVisAVisFlap