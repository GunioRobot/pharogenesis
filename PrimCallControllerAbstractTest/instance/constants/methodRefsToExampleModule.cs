methodRefsToExampleModule
	^ self methodSelectorsToExampleModule
		collect: [:sym | MethodReference new setStandardClass: self class methodSymbol: sym]