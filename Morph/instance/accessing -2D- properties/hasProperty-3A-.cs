hasProperty: aSymbol 
	"Answer whether the receiver has the property named aSymbol"
	self hasExtension
		ifFalse: [^ false].
	^ self extension hasProperty: aSymbol