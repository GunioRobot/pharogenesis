referencesToIt
	"Open a references browser on the selected symbol"
	| aSymbol |
	self selectionInterval isEmpty ifTrue: [self selectWord].
	((aSymbol _ self selectedSymbol) == nil or:
		[(Smalltalk includesKey: aSymbol) not])
			ifTrue: [^ view flash].

	self terminateAndInitializeAround: [Smalltalk browseAllCallsOn: (Smalltalk associationAt: self selectedSymbol)]