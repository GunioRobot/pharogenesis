remapFieldsAndClassOf: oop
	"Replace all forwarded pointers in this object with their new oops, using the forwarding table. Remap its class as well, if necessary."
	"Note: The given oop may be forwarded itself, which means that its real header is in its forwarding table entry."

	| fieldOffset fieldOop fwdBlock newOop |
	self inline: true.
	fieldOffset _ self lastPointerWhileForwarding: oop.
	[fieldOffset >= BaseHeaderSize] whileTrue: [
		fieldOop _ self longAt: (oop + fieldOffset).
		(self isObjectForwarded: fieldOop) ifTrue: [
			"update this oop from its forwarding block"
			fwdBlock _ ((self longAt: fieldOop) bitAnd: AllButMarkBitAndTypeMask) << 1.
			DoAssertionChecks ifTrue: [ self fwdBlockValidate: fwdBlock ].
			newOop _ self longAt: fwdBlock.
			self longAt: (oop + fieldOffset) put: newOop.

			"The following ensures that become: into old object makes it a root.
			  It does nothing during either incremental or full compaction because
			  oop will never be < youngStart."
			((oop < youngStart) and: [newOop >= youngStart])
				ifTrue: [ self beRootWhileForwarding: oop ].
		].
		fieldOffset _ fieldOffset - 4.
	].
	self remapClassOf: oop.