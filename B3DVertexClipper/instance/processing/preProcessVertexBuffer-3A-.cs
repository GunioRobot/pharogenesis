preProcessVertexBuffer: vb
	"Clip the elements in the vertex buffer. Return true if all vertices are inside.
	Return false if all vertices are outside. If partial clipping occurs, return nil."
	| fullMask |
	fullMask _ self determineClipFlags: vb vertexArray count: vb vertexCount.
	vb clipFlags: fullMask.
	"Check if all vertices are inside, so no clipping is necessary"
	(fullMask allMask: InAllMask) ifTrue:[^true].
	"Check if all vertices are outside, so we can get rid of the entire buffer"
	(fullMask anyMask: OutAllMask) ifTrue:[
		"Reset the number of vertices in the vertex buffer to zero to indicate all outside"
		vb reset.
		^false].
	^nil