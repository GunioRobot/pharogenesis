incCompMakeFwd
	"Create and initialize forwarding blocks for all non-free objects following compStart. If the supply of forwarding blocks is exhausted, set compEnd to the first chunk above the area to be compacted; otherwise, set it to endOfMemory. Return the number of bytes to be freed."

	| bytesFreed oop fwdBlock newOop |
	bytesFreed _ 0.
	oop _ self oopFromChunk: compStart.
	[oop < endOfMemory] whileTrue: [
		(self isFreeObject: oop) ifTrue: [
			bytesFreed _ bytesFreed + (self sizeOfFree: oop).
		] ifFalse: [
			"create a forwarding block for oop"
			fwdBlock _ self fwdBlockGet: 8.  "Two-word block"
			fwdBlock = nil ifTrue: [
				"stop; we have used all available forwarding blocks"
				compEnd _ self chunkFromOop: oop.
				^ bytesFreed
			].

			newOop _ oop - bytesFreed.
			self initForwardBlock: fwdBlock mapping: oop to: newOop withBackPtr: false.
		].
		oop _ self objectAfterWhileForwarding: oop.
	].
	compEnd _ endOfMemory.
	^ bytesFreed