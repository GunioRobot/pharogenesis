netAddressToInt: oop
	"Convert the given internet network address (represented as a four-byte ByteArray) into a 32-bit integer. Fail if the given oop is not a four-byte ByteArray."

	| sz |
	self successIfClassOf: oop is: (self splObj: ClassByteArray).
	successFlag ifTrue: [
		sz _ self lengthOf: oop.
		sz = 4 ifFalse: [^ self primitiveFail]].
	successFlag ifTrue: [
		^ (self fetchByte: 3 ofObject: oop) +
		  ((self fetchByte: 2 ofObject: oop) << 8) +
		  ((self fetchByte: 1 ofObject: oop) << 16) +
		  ((self fetchByte: 0 ofObject: oop) << 24) ].