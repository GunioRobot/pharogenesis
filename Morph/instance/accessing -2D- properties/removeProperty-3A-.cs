removeProperty: aSymbol 
	"removes the property named aSymbol if it exists"
	self hasExtension
		ifFalse: [^ self].
	self extension removeProperty: aSymbol