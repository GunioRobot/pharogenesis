mapContextCache
	"Assumes: SP and IP are external and valid for the activeCachedContext."

	| ctx tmp acc |
	self inline: true.
	acc _ activeCachedContext.
	acc = 0 ifFalse: [
		ctx _ lowestCachedContext.
		tmp _ self basicCachedSenderAt: ctx.
		self basicCachedSenderAt: ctx put: (self remap: tmp).
		[ctx = 0] whileFalse: [
			self mapCachedContext: ctx.
			ctx = acc
				ifTrue: [ctx _ 0]
				ifFalse: [ctx _ self cachedContextAfter: ctx].
		].
	].