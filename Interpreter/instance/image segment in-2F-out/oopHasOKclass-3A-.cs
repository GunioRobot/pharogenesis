oopHasOKclass: oop
	"Similar to oopHasOkayClass:, except that it only returns true or false."

	| oopClass formatMask behaviorFormatBits oopFormatBits |
	(self isIntegerObject: oop) ifTrue: [^ true].
	((0 < oop) & (oop < endOfMemory)) ifFalse: [^ false].
	((oop \\ 4) = 0) ifFalse: [^ false].
	(oop + (self sizeBitsOf: oop)) < endOfMemory ifFalse: [^ false].
	oopClass _ self fetchClassOf: oop.

	(self isIntegerObject: oopClass) ifTrue: [^ false].
	((0 < oopClass) & (oopClass < endOfMemory)) ifFalse: [^ false].
	((oopClass \\ 4) = 0) ifFalse: [^ false].
	(oopClass + (self sizeBitsOf: oopClass)) < endOfMemory ifFalse: [^ false].
	((self isPointers: oopClass) and: [(self lengthOf: oopClass) >= 3]) ifFalse: [^ false].
	(self isBytes: oop)
		ifTrue: [ formatMask _ 16rC00 ]  "ignore extra bytes size bits"
		ifFalse: [ formatMask _ 16rF00 ].

	behaviorFormatBits _ (self formatOfClass: oopClass) bitAnd: formatMask.
	oopFormatBits _ (self baseHeader: oop) bitAnd: formatMask.
	behaviorFormatBits = oopFormatBits ifFalse: [^ false].
	^ true