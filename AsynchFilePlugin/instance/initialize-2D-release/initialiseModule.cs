initialiseModule
	"Initialise the module"
	self export: true.
	sCOAFfn _ interpreterProxy ioLoadFunction: 'secCanOpenAsyncFileOfSizeWritable' From: 'SecurityPlugin'.
	^self cCode: 'asyncFileInit()' inSmalltalk:[true]