sizeOfSTArrayFromCPrimitive: cPtr
	"Note: Only called by translated primitive code."
	self var: #cPtr declareC: 'void *cPtr'.
	^self shouldNotImplement