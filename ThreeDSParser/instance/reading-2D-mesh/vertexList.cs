vertexList
	"Subchunk of triMesh"
	| count vertices |
	count := self uShort.
	vertices := self vertexArrayClass new: count.
	1 to: count do: [:i |
		vertices at: i put: self vector3].
	^vertices