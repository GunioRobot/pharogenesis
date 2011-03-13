new: nElements
	"Create a Dictionary large enough to hold nElements without growing.
	Note that the basic size must be a power of 2."
	| size |
	size _ (self sizeFor: nElements).
	size isPowerOfTwo ifFalse:
		["Size must be a power of 2..."
		size _ 1 bitShift: size highBit].
	size >= 1 ifFalse: [self error: 'size must be >= 1'].
	^ (self basicNew: size) init: size