nonLocalBlockReturn: value
	"Return value to the sender of the home context.  Not inlined into the interpreter loop since
		(a)	it isn't that fast compared to externalising ip/sp and a function call;
		(b)	it causes a proliferation of temporary variables in interpret();
		(c)	it isn't executed particularly frequently."

	| home cp ctx returnContext senderContext nilOop |
	self inline: false.
	self assertStackPointerIsExternal.
	nilOop _ nilObj.
	home _ self cachedHomeAt: activeCachedContext.
	(self isPseudoContext: home) ifTrue: [
		cp _ self pseudoCachedContextAt: home.
		[activeCachedContext == cp] whileFalse: [
			(self cachedSenderAt: activeCachedContext) = nilObj ifTrue: [^self cannotReturn: value].
			self deallocateCachedContext.
		].
		(self cachedSenderAt: activeCachedContext) = nilObj ifTrue: [^self cannotReturn: value].
		self deallocateCachedContext.		"return from home context"
	] ifFalse: [
		"Check that it is possible to reach the return context from the active context"
		returnContext _ self fetchPointer: SenderIndex ofObject: home.
		returnContext == nilOop ifTrue: [^self cannotReturn: value].

		"Do a quick search for the return context.  If it's not found, raise the error in the
		context that is trying to return.  (The cost of this is almost unmeasurably small.)"
		ctx _ self cachedSenderAt: lowestCachedContext.
		[ctx ~= returnContext and: [ctx ~= nilOop]] whileTrue: [
			ctx _ self fetchPointer: SenderIndex ofObject: ctx.
		].
		ctx == nilOop ifTrue: [^self cannotReturn: value].

		"Unwind the stack, zapping sender fields to prevent further use"
		ctx _ self deallocateAllCachedContexts.
		[ctx ~= returnContext] whileTrue: [
			senderContext _ self fetchPointer: SenderIndex ofObject: ctx.
			senderContext == nilOop ifTrue: [
				"Returns crossing process boundaries terminate the active process"
				self copyContextToCache: ctx.
				self fetchContextRegisters: ctx.
				^self cannotReturn: value.		"does Processor terminateActive in image"
			].
			self storePointerUnchecked: SenderIndex ofObject: ctx withValue: nilOop.
			ctx _ senderContext.
		].
		"Resume execution in the returnContext"
		self copyContextToCache: returnContext.
	].
	self fetchContextRegisters: activeCachedContext.
	self push: value.
	self quickCheckForInterrupts.
