primOSACompile: anAEDesc mode: anInteger to: anOSAID

	<primitive: 'primOSACompile' module: 'TestOSAPlugin'>
	^TestOSAPlugin 
		doPrimitive: 'primOSACompile:mode:to:'
		withArguments: {anAEDesc. anInteger. anOSAID}