primOSAGetScriptInfo: aScriptID type: aDescType to: resultData

	<primitive: 'primOSAGetScriptInfo' module: 'TestOSAPlugin'>
	^TestOSAPlugin 
		doPrimitive: 'primOSAGetScriptInfo:type:to:'
		withArguments: {aScriptID. aDescType. resultData}