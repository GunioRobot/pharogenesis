ejectMethodCacheLine: index

	| tMeth |

	EagerInlineCacheFlush ifTrue: [
		"Invalidate the outgoing translated method"
		tMeth _ methodCache at: index + MethodCacheTMethodCol.
		tMeth = 0 ifFalse: [
			self assertIsTranslatedMethod: tMeth.
			self storePointerUnchecked: MethodLinkageIndex ofObject: tMeth
							withValue: ConstInvalidLinkage]]