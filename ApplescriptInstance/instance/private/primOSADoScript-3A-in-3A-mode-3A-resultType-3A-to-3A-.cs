primOSADoScript: source in: context mode: mode resultType: type to: result

	<primitive: 'primOSADoScript' module: 'TestOSAPlugin'>
	^TestOSAPlugin
		doPrimitive: 'primOSADoScript:in:mode:resultType:to:'
		withArguments: {source. context. mode. type. result}