chunkFromOop: oop
	"Compute the chunk of this oop by subtracting its extra header bytes."

	| extra |
	extra _ self extraHeaderBytes: oop.
	^ oop - extra