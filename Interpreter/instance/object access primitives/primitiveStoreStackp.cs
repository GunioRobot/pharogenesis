primitiveStoreStackp
	"Atomic store into context stackPointer. 
	Also ensures that any newly accessible cells are initialized to nil "
	| ctxt newStackp stackp |
	ctxt _ self stackValue: 1.
	newStackp _ self stackIntegerValue: 0.
	self success: newStackp >= 0.
	self success: newStackp <= (LargeContextSize - BaseHeaderSize // 4 - CtxtTempFrameStart).
	successFlag ifFalse: [^ self primitiveFail].
	stackp _ self fetchStackPointerOf: ctxt.
	newStackp > stackp ifTrue: ["Nil any newly accessible cells"
			stackp + 1 to: newStackp do: [:i | self storePointer: i + CtxtTempFrameStart - 1 ofObject: ctxt withValue: nilObj]].
	self storeStackPointerValue: newStackp inContext: ctxt.
	self pop: 1