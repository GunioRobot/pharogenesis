setColorVector: aColor
	"Instaneously sets the object's color/alpha vector and copies it down the object tree for all objects that are parts of this object"

	"Set our color"
	myColor _ aColor.

	lightColor ambientPart: myColor.
	lightColor diffusePart: myColor.
	lightColor specularPart: myColor.

	myMaterial ambientPart: myColor.
	myMaterial diffusePart: myColor.
	myMaterial specularPart: myColor.

	"Set the color of our parts"
	myChildren do: [:child | (child isPart) ifTrue: [child setColorVector: aColor] ].
