primitiveInitializeNetwork: resolverSemaIndex

	| err |
	self primitive: 'primitiveInitializeNetwork'
		parameters: #(SmallInteger).
	err _ self sqNetworkInit: resolverSemaIndex.
	interpreterProxy success: err = 0