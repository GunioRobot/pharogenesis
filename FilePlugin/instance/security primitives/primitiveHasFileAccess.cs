primitiveHasFileAccess
	|  hasAccess |
	self export: true.
	"If the security plugin can be loaded, use it to check . 
	If not, assume 
	it's ok"
	sHFAfn ~= 0
		ifTrue: [hasAccess _ self cCode: ' ((int (*) (void)) sHFAfn)()' inSmalltalk: [true]]
		ifFalse: [hasAccess _ true].
	interpreterProxy pop: 1.
	interpreterProxy pushBool: hasAccess