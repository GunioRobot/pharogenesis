initialiseModule
	self export: true.
	^self cCode: 'sqUUIDInit()' inSmalltalk:[true]