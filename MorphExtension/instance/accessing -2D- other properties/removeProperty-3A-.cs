removeProperty: aSymbol 
	"removes the property named aSymbol if it exists"
	self hasOtherProperties
		ifFalse: [^ self].
	self otherProperties
		removeKey: aSymbol
		ifAbsent: [].
	self otherProperties isEmpty
		ifTrue: [self removeOtherProperties]