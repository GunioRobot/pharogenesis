recognize: dispatcherArray do: aBlock
	"Provide default end position"

	self recognize: dispatcherArray do: aBlock inChunksUpTo: chunkPos + chunkLen