new: nElements
	"Create a Dictionary large enough to hold nElements without growing.
	Note that the basic size must be a power of 2.
	It is VITAL (see grow) that size gets doubled if nElements is a power of 2"
	| size |
	size _ 1 bitShift: nElements highBit.
	^ (self basicNew: size) init: size