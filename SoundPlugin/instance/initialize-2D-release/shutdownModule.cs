shutdownModule
	self export: true.
	^self cCode: 'soundShutdown()' inSmalltalk:[true]