primAECreateDesc: typeCode from: aString

	<primitive: 'primAECreateDesc' module: 'TestOSAPlugin'>
	^TestOSAPlugin 
		doPrimitive: 'primAECreateDesc:from:'	
		withArguments: {typeCode. aString}