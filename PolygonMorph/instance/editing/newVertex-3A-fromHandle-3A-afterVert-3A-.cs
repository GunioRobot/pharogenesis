newVertex: evt fromHandle: handle afterVert: ix
	"Insert a new vertex and fix everything up! Install the drag-handle of the new vertex as recipient of further mouse events."

	| pt |
	pt _ evt cursorPoint.
	self setVertices: (vertices copyReplaceFrom: ix + 1 to: ix with: (Array with: pt)).
	evt hand newMouseFocus: (handles at: ((ix + 1) * 2) - 1).
