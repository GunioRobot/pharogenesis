loadIndexed: idxArray vertices: vertices normals: normals colors: colors texCoords: texCoords
	| vtxSize idxSize maxVtx maxIdx |
	"Check the size of the vertex array"
	vtxSize _ vertices size.	
	vertexCount + vtxSize >= vertexArray size ifTrue:[
		self growVertexArray: (vtxSize + vertexArray size + 100).
	].
	"Check the size of the index array"
	idxSize _ idxArray basicSize.
	indexCount + idxSize >= indexArray size ifTrue:[
		self growIndexArray: (idxSize + indexArray size + 100).
	].
	"Check the sizes of normals, colors, and texCoords"
	(normals notNil and:[vtxSize ~= normals size]) ifTrue:[^self errorSizeMismatch].
	(colors notNil and:[vtxSize ~= colors size]) ifTrue:[^self errorSizeMismatch].
	(texCoords notNil and:[vtxSize ~= texCoords size]) ifTrue:[^self errorSizeMismatch].
	"Turn off the appropriate flags if no attributes are given.
	Default to having vertex normals and texture coords."
	flags _ flags bitOr: (VBVtxHasNormals + VBVtxHasTexCoords).
	"Turn off tracking flags if no colors are given"
	colors ifNil:[flags _ flags bitAnd: VBNoTrackMask].
	normals ifNil:[flags _ flags bitAnd: VBVtxHasNormals bitInvert32].
	texCoords ifNil:[flags _ flags bitAnd: VBVtxHasTexCoords bitInvert32].
	"Load the vertices"
	maxVtx _ self primLoadVB: vertexArray
					startingAt: vertexCount
					vertices: vertices 
					normals: normals 
					colors: colors 
					texCoords: texCoords 
					count: vtxSize
					default: current.
	"Load the indexes"
	maxIdx _ self 
				primLoadIndexArrayInto: indexArray 
				startingAt: indexCount 
				from: idxArray 
				count: idxSize 
				max: maxVtx 
				offset: vertexCount.
	"Adjust the size of the vertex array and the index array"
	vertexCount _ vertexCount + maxVtx.
	indexCount _ indexCount + maxIdx.