primOSALoad: anAEDesc mode: anInteger to: anOSAID

	<primitive: 'primOSALoad' module: 'TestOSAPlugin'>
	^TestOSAPlugin 
		doPrimitive: 'primOSALoad:mode:to:'
		withArguments: {anAEDesc. anInteger. anOSAID}