ffiTestFloats: f1 with: f2
	"FFITester ffiTestFloats: $A with: 65.0"
	<cdecl: float 'ffiTestFloats' (float float) module:'SqueakFFIPrims'>
	^self externalCallFailed