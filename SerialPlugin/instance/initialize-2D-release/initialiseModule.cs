initialiseModule
	self export: true.
	^self cCode: 'serialPortInit()' inSmalltalk:[true]