disposeMenuBar: aWindowIndex
	(self isVMMenuBar: aWindowIndex) ifTrue: [^self].
	menuBar ifNotNil: [self primDisposeMenuBar: menuBar].
	menuBar := nil