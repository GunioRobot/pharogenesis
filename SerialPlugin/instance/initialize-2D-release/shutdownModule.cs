shutdownModule
	self export: true.
	^self cCode: 'serialPortShutdown()' inSmalltalk:[true]