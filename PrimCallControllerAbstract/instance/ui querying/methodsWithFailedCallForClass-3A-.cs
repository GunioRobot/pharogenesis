methodsWithFailedCallForClass: class 
	^ class selectors
		collect: [:sel | MethodReference new setStandardClass: class methodSymbol: sel]
		thenSelect: [:mRef | self existsFailedCallIn: mRef]