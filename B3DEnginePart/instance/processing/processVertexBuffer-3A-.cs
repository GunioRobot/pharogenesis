processVertexBuffer: vb
	"Process the given vertex buffer in this part of the engine."
	^self perform: (PrimitiveActions at: vb primitive) with: vb