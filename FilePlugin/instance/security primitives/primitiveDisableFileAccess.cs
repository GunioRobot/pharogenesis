primitiveDisableFileAccess

	self export: true.
	"If the security plugin can be loaded, use it to turn off file access
	If 
	not, assume it's ok"
	sDFAfn ~= 0
		ifTrue: [self cCode: ' ((int (*) (void)) sDFAfn)()'].
	interpreterProxy failed
		ifFalse: [interpreterProxy pop: 1]