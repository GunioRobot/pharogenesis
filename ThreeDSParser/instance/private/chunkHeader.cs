chunkHeader
	"Read header of a chunk, store in instance variables"

	chunkPos := source position.
	chunkID := self uShort.
	chunkLen := self long.
	self informer value: chunkPos.
	self printChunkInfo