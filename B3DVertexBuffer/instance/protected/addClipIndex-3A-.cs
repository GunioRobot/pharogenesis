addClipIndex: index
	"Add a primitive index to the list of indexes."
	indexCount >= indexArray size 
		ifTrue:[self growIndexArray: indexCount + (indexCount // 4) + 10].
	indexArray at: (indexCount _ indexCount + 1) put: index.