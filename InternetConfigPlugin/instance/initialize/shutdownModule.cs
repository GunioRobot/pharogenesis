shutdownModule
	self export: true.
	^self cCode: 'sqInternetConfigurationShutdown()' inSmalltalk:[true]