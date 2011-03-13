referencesToIt
	"Open a references browser on the selected symbol"

	| aSymbol |
	self selectLine.
	((aSymbol := self selectedSymbol) == nil or:
		[(Smalltalk includesKey: aSymbol) not])
			ifTrue: [^ self flash].

	self terminateAndInitializeAround: [self systemNavigation browseAllCallsOn: (Smalltalk associationAt: self selectedSymbol)]