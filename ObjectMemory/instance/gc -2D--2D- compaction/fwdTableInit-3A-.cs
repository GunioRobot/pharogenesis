fwdTableInit: blkSize
	"Set the limits for a table of two- or three-word forwarding blocks above the last used oop. The pointer fwdTableNext moves up to fwdTableLast. Used for compaction of memory and become-ing objects. Returns the number of forwarding blocks available."

	self inline: false.
	"set endOfMemory to just after a minimum-sized free block"
	self setSizeOfFree: freeBlock to: BaseHeaderSize.
	endOfMemory _ freeBlock + BaseHeaderSize.

	"make a fake free chunk at endOfMemory for use as a sentinal in memory scans"
	self setSizeOfFree: endOfMemory to: BaseHeaderSize.

	"use all memory free between freeBlock and memoryLimit for forwarding table"
	"Note: Forward blocks must be quadword aligned."
	fwdTableNext _ (endOfMemory + BaseHeaderSize + 7) bitAnd: 16rFFFFFFF8.
	fwdTableLast _ memoryLimit - blkSize.  "last forwarding table entry"

	"return the number of forwarding blocks available"
	^ (fwdTableLast - fwdTableNext) // blkSize  "round down"