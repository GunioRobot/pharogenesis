primOSAGetSource: aScriptID type: aDescType to: resultData

	<primitive: 'primOSAGetSource' module: 'TestOSAPlugin'>
	^TestOSAPlugin 
		doPrimitive: 'primOSAGetSource:type:to:'
		withArguments: {aScriptID. aDescType. resultData}