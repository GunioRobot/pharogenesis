fwdTableSize: blkSize
	"Estimate the number of forwarding blocks available for compaction"
	| eom fwdFirst fwdLast |
	self inline: false.

	eom _ freeBlock + BaseHeaderSize.
	"use all memory free between freeBlock and memoryLimit for forwarding table"

	"Note: Forward blocks must be quadword aligned."
	fwdFirst _ (eom + BaseHeaderSize + 7) bitAnd: 16rFFFFFFF8.
	fwdLast _ memoryLimit - blkSize.  "last forwarding table entry"

	"return the number of forwarding blocks available"
	^ (fwdLast - fwdFirst) // blkSize  "round down"