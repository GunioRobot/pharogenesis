initialiseModule
	"Initialise the module"
	self export: true.
	^self cCode: 'asyncFileInit()' inSmalltalk:[true]