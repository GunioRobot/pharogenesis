flushExternalPrimitiveOf: methodPtr
	"methodPtr is a CompiledMethod containing an external primitive. Flush the function address and session ID of the CM"
	| lit |
	(self literalCountOf: methodPtr) > 0 ifFalse:[^self]. "Something's broken"
	lit _ self literal: 0 ofMethod: methodPtr.
	((self fetchClassOf: lit) = (self splObj: ClassArray) and:[(self lengthOf: lit) = 4])
		ifFalse:[^self]. "Something's broken"
	self storeInteger: 2 ofObject: lit withValue: 0.
	self storeInteger: 3 ofObject: lit withValue: 0.
