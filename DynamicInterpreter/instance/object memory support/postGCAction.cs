postGCAction

	| acc |
"	self mapCachedTemporaryPointers."
	acc _ activeCachedContext.
	acc = 0 ifFalse: [
		self addRootsForCachedContext: acc.
		self setTemporaryPointer: (self temporaryPointerForCachedContext: acc).
		checkAssertions ifTrue:
			[self verifyStack.
			 self verifyMethodCache].
	].