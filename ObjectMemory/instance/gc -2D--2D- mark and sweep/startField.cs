startField
	"Examine and possibly trace the next field of the object being traced. See comment in markAndTrace for explanation of tracer state variables."

	| typeBits childType |
	self inline: true.

	child _ self longAt: field.
	typeBits _ child bitAnd: TypeMask.

	(typeBits bitAnd: 1) = 1 ifTrue: [
		"field contains a SmallInteger; skip it"
		field _ field - 4.
		^ StartField
	].

	typeBits = 0 ifTrue: [
		"normal oop, go down"
		self longAt: field put: parentField.
		parentField _ field.
		^ StartObj
	].

	typeBits = 2 ifTrue: [
		"reached the header; do we need to process the class word?"
		(child bitAnd: CompactClassMask) ~= 0 ifTrue: [
			"object's class is compact; we're done"
			"restore the header type bits"
			child _ child bitAnd: AllButTypeMask.
			childType _ self rightType: child.
			self longAt: field put: (child bitOr: childType).
			^ Upward
		] ifFalse: [
			"object has a full class word; process that class"
			child _ self longAt: (field - 4).  "class word"
			child _ child bitAnd: AllButTypeMask.  "clear type bits"
			self longAt: (field - 4) put: parentField.
			parentField _ (field - 4) bitOr: 1.  "point at class word; mark as working on the class."
			^ StartObj
		].
	].