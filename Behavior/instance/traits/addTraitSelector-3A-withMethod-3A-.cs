addTraitSelector: aSymbol withMethod: aCompiledMethod
	self basicAddTraitSelector: aSymbol withMethod: aCompiledMethod.
	aCompiledMethod sendsToSuper ifTrue: [
		self recompile: aSymbol]