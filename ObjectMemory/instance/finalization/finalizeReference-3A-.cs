finalizeReference: oop
	"During sweep phase we have encountered a weak reference. Check if
	its object has gone away (or is about to) and if so, signal a semaphore."
	| weakOop oopGone chunk firstField lastField |
	"Do *not* inline this in sweepPhase - it is quite an unlikely case to run into a weak reference"
	self inline: false.
	firstField := BaseHeaderSize + ((self nonWeakFieldsOf: oop) << 2).
	lastField := self lastPointerOf: oop.
	firstField to: lastField by: 4 do:[:i|
		weakOop := self longAt: oop+i.
		((weakOop == nilObj) or:[(self isIntegerObject: weakOop)]) ifFalse:[
			"Check if the object is being collected.
			If the weak reference points 
				* backward: check if the weakOops chunk is free
				* forward: check if the weakOoop has been marked by GC"
			weakOop < oop 
				ifTrue:[	chunk _ self chunkFromOop: weakOop.
						oopGone _ ((self longAt: chunk) bitAnd: TypeMask) = HeaderTypeFree]
				ifFalse:[oopGone _ ((self baseHeader: weakOop) bitAnd: MarkBit) = 0].
			oopGone ifTrue:[
					"Store nil in the pointer and signal the interpreter"
					self longAt: oop+i put: nilObj.
					self signalFinalization: oop].
		].
	].