primitiveGetNextEvent
	"Primitive. Return the next input event from the OS event queue."
	| evtBuf arg value |
	self var: #evtBuf declareC:'int evtBuf[8] = { 0, 0, 0, 0, 0, 0, 0, 0 }'.
	self cCode:'' inSmalltalk:[evtBuf _ CArrayAccessor on: (IntegerArray new: 8)].
	arg _ self stackValue: 0.
	((self fetchClassOf: arg) = self classArray 
		and:[(self slotSizeOf: arg) = 8]) 
			ifFalse:[^self primitiveFail].
	self ioGetNextEvent: (self cCoerce: evtBuf to: 'sqInputEvent*').
	successFlag ifFalse:[^nil].
	"Event type"
	self 
		storeInteger: 0 
		ofObject: arg 
		withValue: (evtBuf at: 0).
	successFlag ifFalse:[^nil].
	"Event time stamp"
	self 
		storeInteger: 1 
		ofObject: arg 
		withValue: ((evtBuf at: 1) bitAnd: MillisecondClockMask).
	successFlag ifFalse:[^nil].
	"Event arguments"
	2 to: 7 do:[:i|
		value _ evtBuf at: i.
		(self isIntegerValue: value)
			ifTrue:[self storeInteger: i ofObject: arg withValue: value]
			ifFalse:["Need to remap because allocation may cause GC"
				self pushRemappableOop: arg.
				value _ self positive32BitIntegerFor: value.
				arg _ self popRemappableOop.
				self storePointer: i ofObject: arg withValue: value.
			].
	].
	successFlag ifFalse:[^nil].
	self pop: 1.