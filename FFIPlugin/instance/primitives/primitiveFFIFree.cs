primitiveFFIFree
	"Primitive. Free the object pointed to on the external heap."
	| addr oop ptr |
	self export: true.
	self inline: false.
	self var: #ptr declareC:'int *ptr'.
	oop _ interpreterProxy stackObjectValue: 0.
	interpreterProxy failed ifTrue:[^nil].
	(interpreterProxy fetchClassOf: oop) = (interpreterProxy classExternalAddress)
		ifFalse:[^interpreterProxy primitiveFail].
	(interpreterProxy byteSizeOf: oop) = 4
		ifFalse:[^interpreterProxy primitiveFail].
	ptr _ interpreterProxy firstIndexableField: oop.
	addr _ ptr at: 0.
	"Don't you dare to free Squeak's memory!"
	(addr = 0 or:[interpreterProxy isInMemory: addr])
		ifTrue:[^interpreterProxy primitiveFail].
	self ffiFree: addr.
	^ptr at: 0 put: 0. "cleanup"
