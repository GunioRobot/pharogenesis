primitiveHasSocketAccess
	|  hasAccess |
	self export: true.
	interpreterProxy pop: 1.
	"If the security plugin can be loaded, use it to check . 
	If not, assume it's ok"
	sHSAfn ~= 0
		ifTrue: [hasAccess _ self cCode: ' ((int (*) (void)) sHSAfn)()' inSmalltalk:[true]]
		ifFalse: [hasAccess _ true].
	interpreterProxy pop: 1.
	interpreterProxy pushBool: hasAccess