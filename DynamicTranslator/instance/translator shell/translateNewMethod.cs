translateNewMethod
	"Translate the method in newMethod and store the result in newTranslatedMethod."

	"Future optimisations include:
		- make a cache of class-independent quick reponse methods and reuse them
		- pre-translate a method for #doesNotUnderstand:"

	| header nLits bcSize firstBC lastBC tMeth bias prevBC prevOP |
	self inline: false.	"as if you needed telling"

	header _ self headerOf: newMethod.
	nLits _ self literalCountOfHeader: header.
	firstBC _ BaseHeaderSize + "method header" 4 + "literals" (nLits * 4).
	lastBC _ self endPC: newMethod.
	bcSize _ lastBC - firstBC + 1.

	tMeth _ self instantiateClass: (self splObj: ClassTranslatedMethod) indexableSize: MethodOpcodeStart + (2 "words" * bcSize).
	newTranslatedMethod _ tMeth.
	"ASSUME: tMeth is young -- can use unchecked stores.  *** CAVEAT HACOR ***"

	bias _ firstBC - BaseHeaderSize + 1.		"this happens to be the same as the initial vPC for the method"

	self storePointerUnchecked: MethodBiasIndex				ofObject: tMeth
					withValue: (self integerObjectOf: bias).
	self storePointerUnchecked: MethodSelectorIndex			ofObject: tMeth
					withValue: (messageSelector).
	self storePointerUnchecked: MethodArgCountIndex			ofObject: tMeth
					withValue: (self integerObjectOf: (self argumentCountOf: newMethod)).
	self storePointerUnchecked: MethodMethodIndex			ofObject: tMeth
					withValue: (newMethod).
	self storePointerUnchecked: MethodClassIndex				ofObject: tMeth
					withValue: nilObj.	"see #linkSend"
	EagerInlineCacheFlush ifFalse: [
		self storePointerUnchecked: MethodCycleIndex		ofObject: tMeth
					withValue: translationCycle].

	opPointer _ tMeth + BaseHeaderSize + (MethodOpcodeStart * 4) - "pre-incr" 4.	"first opcode"
	bytePointer _ newMethod + firstBC - "pre-incr" 1.								"first bytecode"
	blockEnd _ newMethod.														"not in block"
	[bytePointer < (newMethod + lastBC)] whileTrue: [
		"benign assertions record information needed by later real assertions"
		self assertAny: (prevBC _ bytePointer).
		self assertAny: (prevOP _ opPointer).
		currentByte _ self nextByte.
		self dispatchOn: currentByte in: TranslationTable.
		"assert: bytecodeSize bytes(words) were consumed(generated) in the compiled(translated) method.
				(Assumes: currentByte was not modified while translating the bytecode)"
		self assert: (bytePointer = (prevBC + (self bytecodeSize: currentByte))).
		self assert: (opPointer = (prevOP + ((self bytecodeSize: currentByte) * 8))).
	].

	"assert: byte(op)Pointer points to the last element in the compiled(translated) method."
	self assert: (bytePointer = (newMethod + lastBC + 1 - "pre-incr" 1)).
	self assert: (opPointer = (newTranslatedMethod + (self sizeBitsOf: newTranslatedMethod) - "pre-incr" 4)).