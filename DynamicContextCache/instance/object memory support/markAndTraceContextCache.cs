markAndTraceContextCache
	"Assumes: SP and IP are external and valid for the activeCachedContext."

	| ctx tmp acc |
	self inline: true.
	acc _ activeCachedContext.
	acc = 0 ifFalse: [
		self assertStackPointerIsExternal.
		self verifyStack.
		ctx _ lowestCachedContext.
		self assertIsCachedContext: ctx.
		tmp _ self cachedSenderAt: ctx.
		self assertIsStableContextOrNil: tmp.
		self markAndTrace: tmp.			"Mark the stable section of the stack".
		[ctx = 0] whileFalse: [
			self markAndTraceCachedContext: ctx.
			ctx = acc
				ifTrue: [ctx _ 0]
				ifFalse: [ctx _ self cachedContextAfter: ctx].
		].
	].