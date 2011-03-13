shutdownModule
	self export: true.
	^self cCode: 'dropShutdown()' inSmalltalk:[true]