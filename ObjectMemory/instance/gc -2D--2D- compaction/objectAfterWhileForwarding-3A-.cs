objectAfterWhileForwarding: oop
	"Return the oop of the object after the given oop when the actual header of the oop may be in the forwarding table."

	| header fwdBlock realHeader sz |
	self inline: true.
	header _ self longAt: oop.
	(header bitAnd: MarkBit) = 0 ifTrue: [ ^ self objectAfter: oop ].  "oop not forwarded"

	"Assume: mark bit cannot be set on a free chunk, so if we get here,
	 oop is not free and it has a forwarding table entry"

	fwdBlock _ (header bitAnd: AllButMarkBitAndTypeMask) << 1.
	DoAssertionChecks ifTrue: [ self fwdBlockValidate: fwdBlock ].
	realHeader _ self longAt: fwdBlock + 4.
	"following code is like sizeBitsOf:"
	(realHeader bitAnd: TypeMask) = HeaderTypeSizeAndClass
		ifTrue: [ sz _ (self sizeHeader: oop) bitAnd: AllButTypeMask ]
		ifFalse: [ sz _ realHeader bitAnd: SizeMask ].

	^ self oopFromChunk: (oop + sz)