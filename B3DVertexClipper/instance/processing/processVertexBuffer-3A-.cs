processVertexBuffer: vb
	"Clip the elements in the vertex buffer. Return true if all vertices are inside.
	Return false if all vertices are outside. If partial clipping occurs, return nil."
	| result |
	result _ self preProcessVertexBuffer: vb.
	result == nil ifFalse:[^result].
	^self postProcessVertexBuffer: vb