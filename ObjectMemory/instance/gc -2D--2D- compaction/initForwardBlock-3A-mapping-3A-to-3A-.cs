initForwardBlock: fwdBlock mapping: oop to: newOop
	"Initialize the given forwarding block to map oop to newOop, and replace oop's header with a pointer to the fowarding block."
	"Details: The mark bit is used to indicate that an oop is forwarded. When an oop is forwarded, its header (minus the mark bit) contains the address of its forwarding block. The first word of the forwarding block is the new oop; the second word is the oop's orginal header. The type bits of the forwarding header are the same as those of the original header."

	| originalHeader originalHeaderType |
	self inline: true.
	originalHeader _ self longAt: oop.
	checkAssertions ifTrue: [
		fwdBlock = nil
			ifTrue: [ self error: 'ran out of forwarding blocks in become' ].
		(originalHeader bitAnd: MarkBit) ~= 0
			ifTrue: [ self error: 'object already has a forwarding table entry' ].
	].

	originalHeaderType _ originalHeader bitAnd: TypeMask.
	self longAt: fwdBlock put: newOop.
	self longAt: fwdBlock + 4 put: originalHeader.
	self longAt: oop put: (fwdBlock bitOr: (MarkBit bitOr: originalHeaderType)).