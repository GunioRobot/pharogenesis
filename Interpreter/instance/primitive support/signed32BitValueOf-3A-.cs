signed32BitValueOf: oop
	"Convert the given object into an integer value.
	The object may be either a positive ST integer or a four-byte LargeInteger."
	| sz value largeClass negative |
	self inline: false.
	(self isIntegerObject: oop) ifTrue: [^self integerValueOf: oop].
	largeClass _ self fetchClassOf: oop.
	largeClass = self classLargePositiveInteger
		ifTrue:[negative _ false]
		ifFalse:[largeClass = self classLargeNegativeInteger
					ifTrue:[negative _ true]
					ifFalse:[^self primitiveFail]].
	sz _ self lengthOf: oop.
	sz = 4 ifFalse: [^ self primitiveFail].
	value _ (self fetchByte: 0 ofObject: oop) +
		  ((self fetchByte: 1 ofObject: oop) <<  8) +
		  ((self fetchByte: 2 ofObject: oop) << 16) +
		  ((self fetchByte: 3 ofObject: oop) << 24).
	negative
		ifTrue:[^0 - value]
		ifFalse:[^value]