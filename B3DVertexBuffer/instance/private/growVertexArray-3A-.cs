growVertexArray: newSize
	| newVtxArray |
	newVtxArray _ vertexArray species new: newSize.
	newVtxArray privateReplaceFrom: 1 to: vertexArray basicSize with: vertexArray startingAt: 1.
	vertexArray _ newVtxArray.