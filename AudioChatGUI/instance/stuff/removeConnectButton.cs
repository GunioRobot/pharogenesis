removeConnectButton

	theConnectButton ifNotNil: [
		theConnectButton delete.
		theConnectButton _ nil.
	].