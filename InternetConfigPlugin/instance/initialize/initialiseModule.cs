initialiseModule
	self export: true.
	^self cCode: 'sqInternetConfigurationInit()' inSmalltalk:[true]