newVertex: ix event: evt fromHandle: handle
	"Insert a new vertex and fix everything up! Install the drag-handle of the new vertex as recipient of further mouse events."

	| pt |
	(self hasProperty: #noNewVertices) ifFalse:
		[pt _ evt cursorPoint.
		self setVertices: (vertices copyReplaceFrom: ix + 1 to: ix with: (Array with: pt)).
		evt hand newMouseFocus: (handles at: ((ix + 1) * 2) - 1)]
