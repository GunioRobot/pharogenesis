primGetModuleName
	"If calling this primitive fails, then C module does not exist."
	| strLen strOop strPtr |
	self var: #cString declareC: 'char *cString'.
	self var: #strPtr declareC: 'char *strPtr'.
	self debugCode: [self msg: 'primGetModuleName'].
	self
		primitive: 'primGetModuleName'
		parameters: #()
		receiver: #Oop.
	strLen _ self strlen: self getModuleName.
	strOop _ interpreterProxy instantiateClass: interpreterProxy classString indexableSize: strLen.
	strPtr _ interpreterProxy firstIndexableField: strOop.
	0 to: strLen - 1 do: [:i | strPtr at: i put: (self getModuleName at: i)].
	^ strOop