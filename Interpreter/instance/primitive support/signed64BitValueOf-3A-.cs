signed64BitValueOf: oop
	"Convert the given object into an integer value.
	The object may be either a positive ST integer or a eight-byte LargeInteger."
	| sz value largeClass negative szsqueakInt64 |
	self inline: false.
	self returnTypeC: 'squeakInt64'.
	self var: 'value' type: 'squeakInt64'.
	(self isIntegerObject: oop) ifTrue: [^self cCoerce: (self integerValueOf: oop) to: 'squeakInt64'].
	largeClass _ self fetchClassOf: oop.
	largeClass = self classLargePositiveInteger
		ifTrue:[negative _ false]
		ifFalse:[largeClass = self classLargeNegativeInteger
					ifTrue:[negative _ true]
					ifFalse:[^self primitiveFail]].
	szsqueakInt64 _ self cCode: 'sizeof(squeakInt64)'.
	sz _ self lengthOf: oop.
	sz > szsqueakInt64 
		ifTrue: [^ self primitiveFail].
	value _ 0.
	0 to: sz - 1 do: [:i |
		value _ value + ((self cCoerce: (self fetchByte: i ofObject: oop) to: 'squeakInt64') <<  (i*8))].
	negative
		ifTrue:[^0 - value]
		ifFalse:[^value]