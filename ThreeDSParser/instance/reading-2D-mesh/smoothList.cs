smoothList
	"Optional subchunk of faceList"

	| count smooth |
	count := chunkLen - 6 // 4.
	smooth := Array new: count.
	1 to: count do: [:i | smooth at: i put: self uLong].
	^smooth