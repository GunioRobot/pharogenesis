assertIsValidPseudoContextAt: cp
	| pc cpp |
	pc _ self basicCachedPseudoContextAt: cp.
	pc = 0 ifFalse: [
		cpp _ (self fetchPointer: CachedContextIndex ofObject: pc) - 1.
		self assert: cp = cpp]