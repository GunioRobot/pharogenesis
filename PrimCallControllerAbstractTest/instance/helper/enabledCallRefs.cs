enabledCallRefs
	^ self enabledCallSelectors
		collect: [:sel | MethodReference new setStandardClass: self class methodSymbol: sel]