initialize
	"VRMLEnumerator initialize"
	| selector |
	EnumActions := Dictionary new.
	VRMLNodeSpec initialize.
	VRMLNodeSpec currentSpecs do:[:nodeSpec|
		selector := ('do',nodeSpec name,':') asSymbol.
		EnumActions at: nodeSpec name put: selector.
		(self includesSelector: selector) ifFalse:[
			self compileSelector: selector spec: nodeSpec.
		].
	].