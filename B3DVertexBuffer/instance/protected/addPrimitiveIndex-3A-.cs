addPrimitiveIndex: index
	"Add a primitive index to the list of indexes."
	indexCount >= indexArray size 
		ifTrue:[self growIndexArray: indexCount * 3 // 2 + 100].
	indexArray at: (indexCount _ indexCount + 1) put: index.