initialize
	vertexArray _ B3DPrimitiveVertexArray new: 100.
	vertexCount _ 0.
	indexArray _ WordArray new: 100.
	indexCount _ 0.
	current _ B3DPrimitiveVertex new.
	flags _ 0.
	primitive _ nil.