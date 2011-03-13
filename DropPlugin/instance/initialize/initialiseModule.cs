initialiseModule
	self export: true.
	^self cCode: 'dropInit()' inSmalltalk:[true]