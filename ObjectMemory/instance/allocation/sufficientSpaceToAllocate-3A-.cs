sufficientSpaceToAllocate: bytes
	"Return true if there is enough space to allocate the given number of bytes, perhaps after doing a garbage collection."

	| minFree |
	self inline: true.
	minFree _ lowSpaceThreshold + bytes + BaseHeaderSize.

	"check for low-space"
	(self sizeOfFree: freeBlock) >= minFree ifTrue: [
		^ true.
	] ifFalse: [
		^ self sufficientSpaceAfterGC: minFree.
	].