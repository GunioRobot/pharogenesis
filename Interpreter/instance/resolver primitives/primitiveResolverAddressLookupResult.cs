primitiveResolverAddressLookupResult

	| sz s |
	sz _ self sqResolverAddrLookupResultSize.
	successFlag ifTrue: [
		s _ self instantiateClass: (self splObj: ClassString) indexableSize: sz.
		self sqResolverAddrLookup: (self cCoerce: (s + BaseHeaderSize) to: 'char *')
			Result: sz.
	].
	successFlag ifTrue: [
		self pop: 1 thenPush: s.
	].
