at: index put: aB3DPrimitiveVertex
	"Store the primitive vertex at the given index in the receiver"
	| idx |
	(index < 1 or:[index > self size]) ifTrue:[^self errorSubscriptBounds: index].
	idx _ index-1*PrimVertexSize.
	self privateReplaceFrom: idx+1 to: idx+PrimVertexSize with: aB3DPrimitiveVertex startingAt: 1.
	^aB3DPrimitiveVertex