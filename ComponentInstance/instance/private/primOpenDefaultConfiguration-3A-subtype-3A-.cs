primOpenDefaultConfiguration: type subtype: subtype

	<primitive: 'primOpenDefaultConfiguration' module: 'TestOSAPlugin'>
	^TestOSAPlugin 
		doPrimitive: 'primOpenDefaultConfiguration:subtype:'
		withArguments: {type. subtype}