addPrimitiveObject: vb ofSize: objSize
	| obj textureIndex |
	texture == nil
		ifTrue:[textureIndex _ 0]
		ifFalse:[textureIndex _ textures at: texture ifAbsentPut:[textures size+1]].
	obj _ B3DPrimitiveRasterizerData new: objSize.
	self primAddObject: obj
		primitive: vb primitive
		vertexArray: vb vertexArray
		size: vb vertexCount
		indexArray: vb indexArray
		size: vb indexCount
		viewport: viewport
		textureIndex: textureIndex.
	primObjects nextPut: obj.
	"AAARRRRGGGGGHHHH - we should do this differently!!!!"
	vbBounds _ (obj integerAt: 9) @ (obj integerAt: 11) corner: (obj integerAt: 10) @ (obj integerAt: 12).