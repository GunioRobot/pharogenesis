privateTransformVB: vb
	"Transform the contents of the vertex buffer.
	Transforming may include normals (if lighting enabled) and textures (if textures enabled)."
	^transformer processVertexBuffer: vb
					modelView: transformer modelViewMatrix
					projection: (transformer projectionMatrix composedWithGlobal: pickMatrix)