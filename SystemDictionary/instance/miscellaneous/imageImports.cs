imageImports
	"Answer the global dictionary of image imports, creating it if necessary.  7/24/96 sw"

	"Smalltalk viewImageImports"
	(self includesKey: #ImageImports)
		ifFalse:
			[self at: #ImageImports put: Dictionary new].
	^ self at: #ImageImports