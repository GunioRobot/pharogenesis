primitiveFFIAllocate
	"Primitive. Allocate an object on the external heap."
	| byteSize addr oop ptr |
	self export: true.
	self inline: false.
	self var: #ptr declareC:'int *ptr'.
	byteSize _ interpreterProxy stackIntegerValue: 0.
	interpreterProxy failed ifTrue:[^nil].
	addr _ self ffiAlloc: byteSize.
	addr = 0 ifTrue:[^interpreterProxy primitiveFail].
	oop _ interpreterProxy 
			instantiateClass: interpreterProxy classExternalAddress 
			indexableSize: 4.
	ptr _ interpreterProxy firstIndexableField: oop.
	ptr at: 0 put: addr.
	interpreterProxy pop: 2.
	^interpreterProxy push: oop.
