isMethodContext: ctx
	"Answer if the stable context ctx is a MethodContext"
	self inline: true.

	self assertIsStableContext: ctx.
	^(self isBlockContext: ctx) not