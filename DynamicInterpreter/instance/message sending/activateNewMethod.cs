activateNewMethod
	"Activate the method in newMethod.  Receiver and arguments are on the stack.
	Assumes:	ArgumentCount is set appropriately.
				The topmost cached context is still active.
				IP and SP are external.
				newTranslatedMethod contains a translation of newMethod"

	| newContext methodHeader tempCount cp newFrame oldSP newSP oldContext argCount nilOop |
	self inline: false.
	self assertStackPointerIsExternal.

	argCount	_ argumentCount.
	oldContext	_ activeCachedContext.
	oldSP		_ self cachedStackPointerAt: oldContext.
	newFrame	_ oldSP - (argCount * 4) + 4.		"first argument"
	newSP		_ newFrame - 8.				"pop arguments and receiver"
	newContext	_ self allocateCachedContextAfter: oldContext frame: newFrame.	"can cause GC!"
	self cachedStackPointerAt: oldContext put: newSP.		"updated AFTER possible GC"

	stackOverflow ifTrue: [
		newFrame _ self cachedFramePointerAt: newContext.
		self	transfer:	argCount
			wordsFrom:	newSP + 8
			to: 			newFrame.
		stackOverflow _ false.
	].

	methodHeader _ self headerOf: newMethod.
	tempCount _ (methodHeader >> 19) bitAnd: 16r3F.

	tempCount > argCount ifTrue: [
		nilOop _ nilObj.
		self fill:		tempCount - argCount
			wordsFrom:	newFrame + (argCount * 4)
			with:		nilOop.
	].

	self cachedMethodAt:			newContext put: (newMethod).
	self cachedTranslatedMethodAt:	newContext put: (newTranslatedMethod).
	self cachedReceiverAt:			newContext put: (self longAt: (newSP + 4)).
	self cachedHomeAt:				newContext put: 0.
	self cachedInstructionPointerAt:	newContext put: (newTranslatedMethod + BaseHeaderSize + ((MethodOpcodeStart - "pre-incr" 1) * 4)).
	self cachedStackPointerAt:		newContext put: (newFrame + (tempCount * 4) - 4).
"	self cachedTemporaryPointerAt:	newContext put: newFrame."
	self setTemporaryPointer: newFrame.

	pseudoReceiver = 0 ifFalse: [
		self assertIsPseudoContext: pseudoReceiver.
		cp _ self pseudoCachedContextAt: pseudoReceiver.
		self flushCacheFrom: cp.
		pseudoReceiver _ 0.
		"self cachedContextReceiverFlagAt: cp put: 1."		"non-zero"	"deprecated"		
	].

