registerLocalSelector: aSymbol
	self basicLocalSelectors notNil ifTrue: [
		self basicLocalSelectors add: aSymbol]