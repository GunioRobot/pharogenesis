translatedMethodOfBlockContext: blockContext
	| home cp tMeth |
	self assertIsStableBlockContext: blockContext.
	home _ self fetchPointer: HomeIndex ofObject: blockContext.
	(self isPseudoContext: home) ifTrue: [
		cp _ self pseudoCachedContextAt: home.
		tMeth _ self cachedTranslatedMethodAt: cp.
	] ifFalse: [
		tMeth _ self fetchPointer: TranslatedMethodIndex ofObject: home.
	].
	self assertIsTranslatedMethod: tMeth.
	^tMeth