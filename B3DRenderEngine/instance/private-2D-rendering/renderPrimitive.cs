renderPrimitive
	"This is the main rendering loop for all operations"
	| visible |
	"Step 1: Check if the mesh is visible at all"
	visible _ self privateVisibleVB: vertexBuffer.
	visible == false ifTrue:[^nil].

	"Step 2: Transform vertices, normals, texture coords of the mesh"
	self privateTransformVB: vertexBuffer.

	"Step 3: Light the vertices of the mesh."
	self privateNeedsShadingVB
		ifTrue:[self privateShadeVB: vertexBuffer].

	"Step 4: Clip the mesh if necessary"
	(self privateNeedsClipVB: visible)
		ifTrue:[visible _ self privateClipVB: vertexBuffer].
	visible == false ifTrue:[^nil].

	"Step 5: Rasterize the mesh"
	^self privateRasterizeVB: vertexBuffer.