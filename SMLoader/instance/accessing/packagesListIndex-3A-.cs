packagesListIndex: anObject
	self selectedItemWrapper: (anObject = 0 ifTrue:[nil] ifFalse: [(self packageWrapperList at: anObject)])
