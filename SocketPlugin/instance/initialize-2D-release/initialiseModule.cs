initialiseModule
	self export: true.
	sDSAfn _ interpreterProxy ioLoadFunction: 'secDisableSocketAccess' From: 'SecurityPlugin'.
	sHSAfn _ interpreterProxy ioLoadFunction: 'secHasSocketAccess' From: 'SecurityPlugin'.
	sCCTPfn _ interpreterProxy ioLoadFunction: 'secCanConnectToPort' From: 'SecurityPlugin'.
	sCCLOPfn _ interpreterProxy ioLoadFunction: 'secCanListenOnPort' From: 'SecurityPlugin'.
	sCCSOTfn _ interpreterProxy ioLoadFunction: 'secCanCreateSocketOfType' From: 'SecurityPlugin'.
	^self cCode: 'socketInit()' inSmalltalk:[true]