recognize: dispatcherArray do: aBlock inChunksUpTo: endPos
	"Scan chunks up to endPos, process those mentioned in dispatcherArray"

	| nextChunkPos item |
	nextChunkPos := source position.
	[nextChunkPos < endPos] whileTrue: [
		"Read header"
		self chunkHeader.
		nextChunkPos := chunkPos + chunkLen.
		"Dispatch"
		(item := self dispatchID: chunkID in: dispatcherArray) notNil
			ifTrue: [aBlock value: item].
		"Skip to next chunk"
		source position = nextChunkPos ifFalse: [
			self logUnreadBytes: nextChunkPos.
			source position: nextChunkPos]].