lastPointerWhileForwarding: oop
	"The given object may have its header word in a forwarding block. Find the offset of the last pointer in the object in spite of this obstacle."

	| header fwdBlock fmt size methodHeader |
	self inline: true.
	header _ self longAt: oop.
	(header bitAnd: MarkBit) ~= 0 ifTrue: [
		"oop is forwarded; get its real header from its forwarding table entry"
		fwdBlock _ (header bitAnd: AllButMarkBitAndTypeMask) << 1.
		DoAssertionChecks ifTrue: [ self fwdBlockValidate: fwdBlock ].
		header _ self longAt: fwdBlock + 4.
	].

	fmt _ (header >> 8) bitAnd: 16rF.
	fmt <= 4 ifTrue:
		[(fmt = 3 and: [self isContextHeader: header]) ifTrue:
			["contexts end at the stack pointer"
			^ (CtxtTempFrameStart + (self fetchStackPointerOf: oop)) * 4].
		"do sizeBitsOf: using the header we obtained"
		(header bitAnd: TypeMask) = HeaderTypeSizeAndClass
			ifTrue: [ size _ (self sizeHeader: oop) bitAnd: AllButTypeMask ]
			ifFalse: [ size _ header bitAnd: SizeMask ].
		^ size - BaseHeaderSize].
	fmt < 12 ifTrue: [ ^ 0 ].  "no pointers"

	methodHeader _ self longAt: oop + BaseHeaderSize.
	^ ((methodHeader >> 10) bitAnd: 16rFF) * 4 + BaseHeaderSize