loadWordTransformFrom: transformOop into: destPtr length: n
	"Load a float array transformation from the given oop"
	| srcPtr |
	self inline: false.
	self var: #srcPtr declareC:'float *srcPtr'.
	self var: #destPtr declareC:'float *destPtr'.
	srcPtr _ self cCoerce: (interpreterProxy firstIndexableField: transformOop) to: 'float *'.
	0 to: n-1 do:[:i| destPtr at: i put: (srcPtr at: i)].