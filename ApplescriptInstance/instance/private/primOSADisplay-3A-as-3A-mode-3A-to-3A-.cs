primOSADisplay: source as: type mode: mode to: result

	<primitive: 'primOSADisplay' module: 'TestOSAPlugin'>
	^TestOSAPlugin 
		doPrimitive: 'primOSADisplay:as:mode:to:'
		withArguments: {source. type. mode. result}