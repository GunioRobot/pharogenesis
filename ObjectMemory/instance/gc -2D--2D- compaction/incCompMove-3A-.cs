incCompMove: bytesFreed
	"Move all non-free objects between compStart and compEnd to their new locations, restoring their headers in the process. Create a new free block at the end of memory. Return the newly created free chunk."
	"Note: The free block used by the allocator always must be the last free block in memory. It may take several compaction passes to make all free space bubble up to the end of memory."

	| oop next fwdBlock newOop header bytesToMove firstWord lastWord newFreeChunk sz |
	newOop _ nil.
	oop _ self oopFromChunk: compStart.
	[oop < compEnd] whileTrue: [
		next _ self objectAfterWhileForwarding: oop.
		(self isFreeObject: oop) ifFalse: [
			"a moving object; unwind its forwarding block"
			fwdBlock _ ((self longAt: oop) bitAnd: AllButMarkBitAndTypeMask) << 1.
			DoAssertionChecks ifTrue: [ self fwdBlockValidate: fwdBlock ].
			newOop _ self longAt: fwdBlock.
			header _ self longAt: fwdBlock + 4.
			self longAt: oop put: header.  "restore the original header"
			bytesToMove _ oop - newOop.

			"move the oop (including any extra header words)"
			sz _ self sizeBitsOf: oop.
			firstWord _ oop - (self extraHeaderBytes: oop).
			lastWord _ (oop + sz) - BaseHeaderSize.
			firstWord to: lastWord by: 4 do: [ :w |
				self longAt: (w - bytesToMove) put: (self longAt: w).
			].
		].
		oop _ next.
	].

	newOop = nil ifTrue: [
		"no objects moved"
		oop _ self oopFromChunk: compStart.
		((self isFreeObject: oop) and: [(self objectAfter: oop) = (self oopFromChunk: compEnd)])
			ifTrue: [ newFreeChunk _ oop ]
			ifFalse: [ newFreeChunk _ freeBlock ].
	] ifFalse: [
		"initialize the newly freed memory chunk"
		"newOop is the last object moved; free chunk starts right after it"
		newFreeChunk _ newOop + (self sizeBitsOf: newOop).
		self setSizeOfFree: newFreeChunk to: bytesFreed.
	].

	DoAssertionChecks ifTrue: [
		(self objectAfter: newFreeChunk) = (self oopFromChunk: compEnd)
			ifFalse: [ self error: 'problem creating free chunk after compaction' ].
	].

	(self objectAfter: newFreeChunk) = endOfMemory ifTrue: [
		self initializeMemoryFirstFree: newFreeChunk.
	] ifFalse: [
		"newFreeChunk is not at end of memory; re-install freeBlock"
		self initializeMemoryFirstFree: freeBlock.
	].

	^ newFreeChunk