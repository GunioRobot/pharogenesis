shutdownModule
	self export: true.
	^self cCode: 'socketShutdown()' inSmalltalk:[true]