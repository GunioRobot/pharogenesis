transformedBy: aMatrix
	"Return a copy of the receiver with its vertices transformed by the given matrix"
	| transformer copy |
	transformer _ B3DVertexTransformer new.
	transformer loadIdentity.
	transformer transformBy: aMatrix.
	copy _ self copy.
	copy position: (transformer transformPosition: position).
	normal == nil
		ifFalse:[copy normal: (transformer transformDirection: normal) safelyNormalize].
	^copy