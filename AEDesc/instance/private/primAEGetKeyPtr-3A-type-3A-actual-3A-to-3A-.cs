primAEGetKeyPtr: keyDesc type: typeDesc actual: ignoreDesc to: aByteArray

	<primitive: 'primAEGetKeyPtr' module: 'TestOSAPlugin'>
	^TestOSAPlugin 
		doPrimitive: 'primAEGetKeyPtr:type:actual:to:'
		withArguments: {keyDesc. typeDesc. ignoreDesc. aByteArray}