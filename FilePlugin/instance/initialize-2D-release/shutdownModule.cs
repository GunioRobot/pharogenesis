shutdownModule
	self export: true.
	^self cCode: 'sqFileShutdown()' inSmalltalk:[true]