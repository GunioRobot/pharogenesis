isStableContext: ctx
	"Answer if the object ctx is a BlockContext or MethodContext"

	self inline: true.
	^(self isPseudoContext: ctx) not