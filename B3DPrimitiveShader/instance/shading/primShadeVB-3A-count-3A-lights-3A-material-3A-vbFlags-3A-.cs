primShadeVB: vertexArray count: vtxCount lights: lightArray material: aMaterial vbFlags: vbFlags
	"Primitive. Shade all the vertices in the vertex buffer using the given array of primitive light sources. Return true on success, false otherwise."
	<primitive: 'b3dShadeVertexBuffer' module:'Squeak3D'>
	self flag: #b3dDebug. self primitiveFailed.
	^false