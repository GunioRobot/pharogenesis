namedObject
	"Subchunk of meshData"
	"Contains triMesh, light, or camera. Answer association"

	| name |
	name := self cString.
	self recognize: #(
		(16r4100 triMesh ->)
		(16r4600 light ->)
		(16r4700 camera ->))
		do: [:item | ^item key -> (name -> item value)].
	^nil