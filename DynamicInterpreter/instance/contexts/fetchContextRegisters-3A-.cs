fetchContextRegisters: ctx
	"No-op.  (The cache interpreter runs directly out of the cached context when IP/SP are external. :)"

	self addRootsForCachedContext: ctx.
	self setTemporaryPointer: (self temporaryPointerForCachedContext: ctx)