primOSAMakeContext: name parent: parent to: result

	<primitive: 'primOSAMakeContext' module: 'TestOSAPlugin'>
	^TestOSAPlugin 
		doPrimitive: 'primOSAMakeContext:parent:to:'
		withArguments: {name. parent. result}