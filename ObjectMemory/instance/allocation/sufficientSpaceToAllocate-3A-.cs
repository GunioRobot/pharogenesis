sufficientSpaceToAllocate: bytes
	"Return true if there is enough space to allocate the given number of bytes, perhaps after doing a garbage collection."

	| minFree |
	self inline: true.
	minFree _ lowSpaceThreshold + bytes + BaseHeaderSize.

	"check for low-space"
	(self cCoerce: (self sizeOfFree: freeBlock) to: 'unsigned ')
		>= (self cCoerce: minFree to: 'unsigned ')
		ifTrue: [^ true]
		ifFalse: [^ self sufficientSpaceAfterGC: minFree].