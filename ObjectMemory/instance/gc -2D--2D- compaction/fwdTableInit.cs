fwdTableInit
	"Set the limits for a table of two-word forwarding blocks above the last used oop. The pointer fwdTableNext moves up to fwdTableLast. Used for compaction of memory and become-ing objects. Returns the number of forwarding blocks available."

	self inline: false.
	"set endOfMemory to just after a minimum-sized free block"
	self setSizeOfFree: freeBlock to: BaseHeaderSize.
	endOfMemory _ freeBlock + BaseHeaderSize.

	"make a fake free chunk at endOfMemory for use as a sentinal in memory scans"
	self setSizeOfFree: endOfMemory to: BaseHeaderSize.

	"use all memory free between freeBlock and memoryLimit for forwarding table"
	fwdTableNext _ endOfMemory + BaseHeaderSize.
	fwdTableLast _ memoryLimit - 8.  "last forwarding table entry"

	(checkAssertions and: [(fwdTableLast bitAnd: MarkBit) ~= 0]) ifTrue: [
		"Note: Address bits must not interfere with the mark bit in header of
		 an object, which shows that the object is forwarded."
		self error: 'fwd table must be in low half of the 32-bit address space'.
	].

	"return the number of forwarding blocks available"
	^ (fwdTableLast - fwdTableNext) // 8  "round down"