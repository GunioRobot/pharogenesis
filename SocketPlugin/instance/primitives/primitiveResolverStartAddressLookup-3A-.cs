primitiveResolverStartAddressLookup: address

	| addr |
	self primitive: 'primitiveResolverStartAddressLookup'
		parameters: #(ByteArray).
	addr _ self netAddressToInt: (self cCoerce: address to: 'unsigned char *').
	interpreterProxy failed ifFalse: [
		self sqResolverStartAddrLookup: addr]