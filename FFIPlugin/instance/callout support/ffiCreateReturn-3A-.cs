ffiCreateReturn: retVal
	"Generic callout support. Create an atomic return value from an external function call"
	| atomicType retOop oop |
	self inline: true.
	interpreterProxy failed ifTrue:[^nil].
	atomicType _ self atomicTypeOf: ffiRetHeader.
	"void returns self"
	atomicType <= FFITypeVoid ifTrue:[
		^interpreterProxy pop: interpreterProxy methodArgumentCount].
	"everything else returns value"
	interpreterProxy pop: 
		interpreterProxy methodArgumentCount+1.
	interpreterProxy pushRemappableOop: ffiRetClass.
	retOop _ self ffiCreateReturnOop: retVal.
	ffiRetClass _ interpreterProxy popRemappableOop.
	ffiRetClass == interpreterProxy nilObject ifTrue:[
		"Just return oop"
		^interpreterProxy push: retOop].
	"Otherwise create an instance of external structure and store the return oop"
	interpreterProxy pushRemappableOop: retOop.
	retOop _ interpreterProxy instantiateClass: ffiRetClass indexableSize: 0.
	oop _ interpreterProxy popRemappableOop.
	interpreterProxy storePointer: 0 ofObject: retOop withValue: oop.
	^interpreterProxy push: retOop.