ffiPrintString: aString
	"FFITester ffiPrintString: 'Hello'"
	<cdecl: char* 'ffiPrintString' (char *)>
	^self externalCallFailed