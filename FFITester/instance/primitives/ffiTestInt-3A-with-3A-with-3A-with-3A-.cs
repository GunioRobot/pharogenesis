ffiTestInt: c1 with: c2 with: c3 with: c4
	"FFITester ffiTestInt: $A with: 65 with: 65.0 with: $A"
	<cdecl: long 'ffiTestInts' (long long long long)>
	^self externalCallFailed