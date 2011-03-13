fileOutPool: aString
	"file out the global pool named aString"
	| f |
	f _ FileStream newFileNamed: aString, '.st'.
	self new fileOutPool: (Smalltalk at: aString asSymbol) onFileStream: f. 	f close.
	