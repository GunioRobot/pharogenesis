disabledCallRefs
	^ self disabledCallSelectors
		collect: [:sel | MethodReference new setStandardClass: self class methodSymbol: sel]