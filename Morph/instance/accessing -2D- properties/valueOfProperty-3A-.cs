valueOfProperty: aSymbol 
	"answer the value of the receiver's property named aSymbol"
	^ self hasExtension
		ifTrue: [self extension valueOfProperty: aSymbol]