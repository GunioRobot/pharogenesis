valueOfProperty: aSymbol ifPresentDo: aBlock 
	"If the receiver has a property of the given name, evaluate  
	aBlock on behalf of the value of that property"
	self hasExtension
		ifFalse: [^ self].
	^ aBlock
		value: (self extension
				valueOfProperty: aSymbol
				ifAbsent: [^ self])