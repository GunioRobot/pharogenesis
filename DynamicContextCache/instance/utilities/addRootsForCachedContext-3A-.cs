addRootsForCachedContext: ctx

	| home |
	home _ self cachedHomeAt: ctx.
	home = 0 ifFalse: [
		(self isStableContext: home) ifTrue: [
			home < youngStart ifTrue: [self beRootIfOld: home].
		].
	].