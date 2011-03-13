referencesToIt
	"Open a references browser on the selected symbol.  1/8/96 sw.
	 2/29/96 sw: select current line first if appropriate, and call selectedSymbol, to avoid pointless interning of spurious selections"

	self selectLine.
	startBlock = stopBlock ifTrue: [view flash. ^ self].
	self terminateAndInitializeAround: [Smalltalk browseAllCallsOn: (Smalltalk associationAt: self selectedSymbol)]