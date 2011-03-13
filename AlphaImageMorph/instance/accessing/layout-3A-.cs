layout: aSymbol
	"Set the value of layout"

	|old|
	(old := layout) = aSymbol ifTrue: [^self].
	layout := aSymbol.
	(old = #scaled or: [aSymbol = #scaled])
		ifTrue: [self cachedForm: nil].
	self changed