isBlockContext: ctx
	"Answer if the stable context ctx is a BlockContext"
	self inline: true.

	self assertIsStableContext: ctx.
	^self isIntegerObject: (self fetchPointer: MethodIndex ofObject: ctx)