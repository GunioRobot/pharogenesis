flushExternalPrimitiveOf: methodPtr
	"methodPtr is a CompiledMethod containing an external primitive. Flush the function address and session ID of the CM"
	| lit |
	(self literalCountOf: methodPtr) > 0 ifFalse:[^nil]. "Something's broken"
	lit _ self literal: 0 ofMethod: methodPtr.
	((self isArray: lit) and:[(self lengthOf: lit) = 4])
		ifFalse:[^nil]. "Something's broken"
	self storeWord: 2 ofObject: lit withValue: ConstZero.
	self storeWord: 3 ofObject: lit withValue: ConstZero.
