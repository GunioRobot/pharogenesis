initialiseModule
	self export: true.
	^self cCode: 'sqFileInit()' inSmalltalk:[true]