processVertexBuffer: vb
	| box vp |
	box _ Array new: 4.
	self primProcessVB: vb vertexArray size: vb vertexCount into: box.
	vp _ self viewport.
	^(vp mapVertex2: (box at: 1) @ (box at: 2)) rect: 
		(vp mapVertex2: (box at: 3) @ (box at: 4))