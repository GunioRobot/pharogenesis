at: index
	"Return the primitive vertex at the given index"
	| vtx |
	(index < 1 or:[index > self size]) ifTrue:[^self errorSubscriptBounds: index].
	vtx _ B3DPrimitiveVertex new.
	vtx privateReplaceFrom: 1 to: vtx size with: self startingAt: index-1*PrimVertexSize+1.
	^vtx