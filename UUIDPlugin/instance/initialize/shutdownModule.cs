shutdownModule
	self export: true.
	^self cCode: 'sqUUIDShutdown()' inSmalltalk:[true]