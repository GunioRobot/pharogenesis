fetchIntegerOrTruncFloat: fieldIndex ofObject: objectPointer
	"Overridden to support the simulator."

	| intOrFloat |
	intOrFloat _ self fetchPointer: fieldIndex ofObject: objectPointer.
	(self isIntegerObject: intOrFloat) ifTrue: [^ self integerValueOf: intOrFloat].
	self successIfClassOf: intOrFloat is: (self splObj: ClassFloat).
	successFlag ifTrue: [^ (self floatValueOf: intOrFloat) truncated].
