renderPrimitive
	"This is the main rendering loop for all operations"
	| visible box |
	"Step 1: Override vertex buffer flags, ignoring normals and tex coords"
	vertexBuffer clearFlags: (VBVtxHasNormals bitOr: VBVtxHasTexCoords).

	"Step 2: Set the primitive type in the vertex buffer to points (that's all we need)"
	vertexBuffer primitive: PrimTypePoints.

	"Step 3: Transform vertices, normals, texture coords of the mesh"
	self privateTransformVB: vertexBuffer.

	"Step 4: Clip the mesh if necessary"
	visible _ self privatePreClipVB: vertexBuffer.
	visible == false ifTrue:[^nil].

	"Step 5: Compute min/max of object vertices."
	box _ self processVertexBuffer: vertexBuffer.
	box == nil ifTrue:[^self].
	bounds == nil 
		ifTrue:[bounds _ box]
		ifFalse:[bounds _ bounds quickMerge: box].
	^bounds