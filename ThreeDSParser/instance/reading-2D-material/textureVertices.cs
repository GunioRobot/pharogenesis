textureVertices
	"Subchunk of tri object"
	| nVerts texCoords u v |
	nVerts := self uShort.
	texCoords := self textureArrayClass new: nVerts.
	1 to: nVerts do:[:i|
		u := self float.
		v := self float.
		texCoords at: i put: (u@v).
	].
	^texCoords.