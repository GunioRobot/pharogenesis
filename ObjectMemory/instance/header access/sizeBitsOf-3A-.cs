sizeBitsOf: oop
	"Answer the number of bytes in the given object, including its base header, rounded up to an integral number of words."
	"Note: byte indexable objects need to have low bits subtracted from this size."

	| header |
	header _ self baseHeader: oop.
	(header bitAnd: TypeMask) = HeaderTypeSizeAndClass
		ifTrue: [ ^ (self sizeHeader: oop) bitAnd: AllButTypeMask ]
		ifFalse: [ ^ header bitAnd: SizeMask ].