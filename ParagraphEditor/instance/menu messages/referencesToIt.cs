referencesToIt
	"Open a references browser on the selected symbol"

	| aSymbol |
	self selectLine.
	((aSymbol _ self selectedSymbol) == nil or:
		[(Smalltalk includesKey: aSymbol) not])
			ifTrue: [^ view flash].

	self terminateAndInitializeAround: [self systemNavigation browseAllCallsOn: (Smalltalk associationAt: self selectedSymbol)]