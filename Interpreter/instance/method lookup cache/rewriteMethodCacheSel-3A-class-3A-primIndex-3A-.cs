rewriteMethodCacheSel: selector class: class primIndex: localPrimIndex
"rewrite the cache entry with the provided prim index and matching function pointer"
	| primPtr |
	self inline: false.
	localPrimIndex = 0
		ifTrue:[primPtr _ 0]
		ifFalse:[primPtr _ self cCoerce: (primitiveTable at: localPrimIndex) to: 'int'].
	self
		rewriteMethodCacheSel: selector class: class
		primIndex: localPrimIndex primFunction: primPtr