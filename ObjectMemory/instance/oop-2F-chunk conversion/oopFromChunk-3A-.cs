oopFromChunk: chunk
	"Compute the oop of this chunk by adding its extra header bytes."

	| extra |
	extra _ self extraHeaderBytes: chunk.
	^ chunk + extra