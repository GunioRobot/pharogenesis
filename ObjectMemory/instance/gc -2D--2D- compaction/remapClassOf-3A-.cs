remapClassOf: oop
	"Update the class of the given object, if necessary, using its forwarding table entry."
	"Note: Compact classes need not be remapped since the compact class field is just an index into the compact class table. The header type bits show if this object has a compact class; we needn't look up the oop's real header."

	| classHeader classOop fwdBlock newClassOop newClassHeader |
	(self headerType: oop) = HeaderTypeShort ifTrue: [ ^nil ].  "compact classes needn't be mapped"

	classHeader _ self longAt: (oop - 4).
	classOop _ classHeader bitAnd: AllButTypeMask.
	(self isObjectForwarded: classOop) ifTrue: [
		fwdBlock _ ((self longAt: classOop) bitAnd: AllButMarkBitAndTypeMask) << 1.
		DoAssertionChecks ifTrue: [ self fwdBlockValidate: fwdBlock ].
		newClassOop _ self longAt: fwdBlock.
		newClassHeader _ newClassOop bitOr: (classHeader bitAnd: TypeMask).
		self longAt: (oop - 4) put: newClassHeader.

		"The following ensures that become: into an old object's class makes it a root.
		  It does nothing during either incremental or full compaction because
		  oop will never be < youngStart."
		((oop < youngStart) and: [newClassOop >= youngStart])
			ifTrue: [ self beRootWhileForwarding: oop ].
	].