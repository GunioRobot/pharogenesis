renderPrimitive
	"This is the main rendering loop for all operations"
	| visible minVertex |
	"Step 1: Check if the mesh is visible at all"
	visible _ self privateVisibleVB: vertexBuffer.
	visible == false ifTrue:[^nil].

	"Step 2: Transform vertices, normals, texture coords of the mesh"
	self privateTransformVB: vertexBuffer.

	"Step 3: Clip the mesh if necessary"
	visible _ self privateClipVB: vertexBuffer.
	visible == false ifTrue:[^nil].

	"Step 4: Collect the minimal/maximal distances for the current object."
	minVertex _ self processVertexBuffer: vertexBuffer.
	objects isEmpty ifFalse:[
		objects last value rasterPosZ > minVertex rasterPosZ 
			ifTrue:[objects last value: minVertex].
	].
	^nil