processIndexedQuads: vb
	"Process an indexed quad set"
	| objSize |
	self flag: #workAround. 
	"There's a bug in the primitive code (now fixed) overwriting more
	than the expected size of the buffer. But older VMs are likely to have
	it so here's what we do..."
	objSize _ self primObjectSize + (vb vertexCount + 1 * PrimVertexSize) + (
		"Workaround for bug in the primitive"
		vb indexCount // 4 * 6 "<- this is what we really need (nQuads * 2 * 3 words per tri)" 
		* 2 "BUG BUG BUG").
	self addPrimitiveObject: vb ofSize: objSize.