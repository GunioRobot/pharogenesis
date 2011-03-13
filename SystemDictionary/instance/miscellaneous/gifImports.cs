gifImports
	"Answer the global dictionary of gif imports, creating it if necessary.  7/24/96 sw"

	"Smalltalk viewGIFImports"
	(self includesKey: #GIFImports)
		ifFalse:
			[self at: #GIFImports put: Dictionary new].
	^ self at: #GIFImports