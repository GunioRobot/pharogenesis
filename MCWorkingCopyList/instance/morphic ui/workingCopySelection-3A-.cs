workingCopySelection: aNumber
	aNumber = 0
		ifTrue: [workingCopy _ nil]
		ifFalse:
			[workingCopy _ self workingCopies at: aNumber].
	self reloadVersionInfos.
	self changed: #workingCopyList; changed: #workingCopySelection; changed: #versionList.
	