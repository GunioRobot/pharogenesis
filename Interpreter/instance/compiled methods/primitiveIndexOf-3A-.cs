primitiveIndexOf: methodPointer
	"Note: We now have 11 bits of primitive index, but they are in two places
	for temporary backward compatibility.  The time to unpack is negligible,
	since the reconstituted full index is stored in the method cache."
	| primBits |
	primBits _ ((self headerOf: methodPointer) >> 1) bitAnd: 16r300001FF.
	primBits > 16r1FF
		ifTrue: [^ (primBits bitAnd: 16r1FF) + (primBits >> 19)]
		ifFalse: [^ primBits]