primitiveResolverAddressLookupResult
	| sz s |
	self primitive: 'primitiveResolverAddressLookupResult'.
	sz _ self sqResolverAddrLookupResultSize.

	interpreterProxy failed
		ifFalse: [s _ interpreterProxy instantiateClass: interpreterProxy classString indexableSize: sz.
			self sqResolverAddrLookup: s asCharPtr Result: sz].
	^ s