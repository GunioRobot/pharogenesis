startIndex: aNumber

	startIndex ~= aNumber ifTrue:  [
		startIndex _ aNumber asInteger.
		self flushCachedForm].
