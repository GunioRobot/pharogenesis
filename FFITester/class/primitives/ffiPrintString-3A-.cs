ffiPrintString: aString
	"FFITester ffiPrintString: 'Hello'"
	<cdecl: char* 'ffiPrintString' (char *) module:'SqueakFFIPrims'>
	^self externalCallFailed