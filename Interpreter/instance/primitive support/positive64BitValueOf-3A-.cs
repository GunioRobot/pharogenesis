positive64BitValueOf: oop
	"Convert the given object into an integer value.
	The object may be either a positive ST integer or a eight-byte LargePositiveInteger."

	| sz szsqueakInt64 value  |
	self returnTypeC: 'squeakInt64'.
	self var: 'value' type: 'squeakInt64'.
	(self isIntegerObject: oop) ifTrue: [
		value _ self integerValueOf: oop.
		value < 0 ifTrue: [^ self primitiveFail].
		^ value].

	self assertClassOf: oop is: (self splObj: ClassLargePositiveInteger).
	successFlag ifFalse: [^ self primitiveFail].
	szsqueakInt64 _ self cCode: 'sizeof(squeakInt64)'.
	sz _ self lengthOf: oop.
	sz > szsqueakInt64
		ifTrue: [^ self primitiveFail].
	value _ 0.
	0 to: sz - 1 do: [:i |
		value _ value + ((self cCoerce: (self fetchByte: i ofObject: oop) to: 'squeakInt64') <<  (i*8))].
	^value.