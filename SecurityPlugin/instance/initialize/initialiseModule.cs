initialiseModule
	self export: true.
	^self cCode: 'ioInitSecurity()' inSmalltalk:[true]