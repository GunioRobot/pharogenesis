initialiseModule
	self export: true.
	^self cCode: 'socketInit()' inSmalltalk:[true]