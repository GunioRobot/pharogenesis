findNextHandlerContextStarting
	"Return the next handler marked context, returning nil if there is none.  Search starts with self and proceeds up to nil."

	| ctx |
	<primitive: 197>
	ctx _ self.
		[ctx isHandlerContext ifTrue:[^ctx].
		(ctx _ ctx sender) == nil ] whileFalse.
	^nil