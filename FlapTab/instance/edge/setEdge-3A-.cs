setEdge: anEdge
	"Set the edge as indicated, if possible"

	| newOrientation |
	self edgeToAdhereTo = anEdge ifTrue: [^ self].
	newOrientation _ nil.
	self orientation == #vertical
		ifTrue: [(#(top bottom) includes: anEdge) ifTrue:
					[newOrientation _ #horizontal]]
		ifFalse: [(#(top bottom) includes: anEdge) ifFalse:
					[newOrientation _ #vertical]].
	self edgeToAdhereTo: anEdge.
	newOrientation ifNotNil: [self transposeParts].
	referent isInWorld ifTrue: [self positionReferent].
	self changeTabText: self existingWording.
	self adjustPositionVisAVisFlap