postProcessVertexBuffer: vb
	"Clip individual items depending on the primitive type"
	vb growForClip. "Make sure we have enough space during primitive operation"
	^super processVertexBuffer: vb.