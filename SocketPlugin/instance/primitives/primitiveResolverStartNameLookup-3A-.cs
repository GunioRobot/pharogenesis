primitiveResolverStartNameLookup: name

	| sz |
	self primitive: 'primitiveResolverStartNameLookup'
		parameters: #(String).
	interpreterProxy failed ifFalse:  [
		sz _ interpreterProxy byteSizeOf: name cPtrAsOop.
		self sqResolverStartName: name Lookup: sz]