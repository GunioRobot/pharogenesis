setTexture: textureFile
	"Sets the object's texture"
	(myWonderland getUndoStack) push: (UndoTextureChange for: self from: myTexture).
	myTexture _ myWonderland makeTextureFrom: textureFile flipping: true.
	myChildren do: [:child | (child isPart) ifTrue: [ child setTexturePointer: myTexture ] ].
