preserveMethodCacheLine: index

	| tMeth |

	EagerInlineCacheFlush ifFalse: [
		"bring this translated method forward into the current cycle"
		tMeth _ methodCache at: index + MethodCacheTMethodCol.
		self assertIsTranslatedMethod: tMeth.
		self storePointerUnchecked: MethodCycleIndex ofObject: tMeth
						withValue: translationCycle]