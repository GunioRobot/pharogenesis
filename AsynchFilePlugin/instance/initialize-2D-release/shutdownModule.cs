shutdownModule
	"Initialise the module"
	self export: true.
	^self cCode: 'asyncFileShutdown()' inSmalltalk:[true]