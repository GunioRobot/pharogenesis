limitHandleMoveEvent: evt from: handle index: index
	"index is the handle index = 1, 2 or 3"
	| ix p ms x points limIx |
	ix _ limits at: index.  "index of corresponding vertex"
	p _ evt cursorPoint adhereTo: graphArea bounds.
	ms _ self msFromX: p x + (self handleOffset: handle) x.

	"Constrain move to adjacent points on ALL envelopes"
	sound envelopes do:
		[:env | limIx _ env perform:
			(#(loopStartIndex loopEndIndex decayEndIndex) at: index).
		ms _ self constrain: ms adjacentTo: limIx in: env points].

	"Update the handle, the vertex and the line being edited"
	x _ self xFromMs: ms.
	handle position: (x @ graphArea top) - (self handleOffset: handle).
	line verticesAt: ix put: x @ (line vertices at: ix) y.

	sound envelopes do:
		[:env | limIx _ env perform:
			(#(loopStartIndex loopEndIndex decayEndIndex) at: index).
		points _ env points.
		points at: limIx put: ms @ (points at: limIx) y.
		env setPoints: points loopStart: env loopStartIndex loopEnd: env loopEndIndex].