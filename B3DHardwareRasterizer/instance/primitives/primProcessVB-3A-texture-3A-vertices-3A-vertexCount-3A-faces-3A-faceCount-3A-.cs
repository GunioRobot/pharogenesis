primProcessVB: primitiveType texture: textureHandle vertices: vtxArray vertexCount: vtxCount faces: idxArray faceCount: idxCount
	<primitive:'primitiveProcessVertexBuffer' module:'Squeak3DX'>
	"There's a bug somewhere in the primitive code leading to failures every now and then which can be safely ignored since the next frame will almost always be fine. I need to track this down but it takes time and these primitive failures are annoying..."
	^nil