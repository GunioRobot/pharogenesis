initialiseModule
	self export: true.
	^self cCode: 'soundInit()' inSmalltalk:[true]