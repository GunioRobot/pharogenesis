addTraitSelector: aSymbol withMethod: aCompiledMethod
	"Add aMethod with selector aSymbol to my
	methodDict. aMethod must not be defined locally.
	Note that I am overridden by ClassDescription
	to do a recompilation of the method if it has supersends."

	self assert: [(self includesLocalSelector: aSymbol) not].
	self ensureLocalSelectors.
	self basicAddSelector: aSymbol withMethod: aCompiledMethod.