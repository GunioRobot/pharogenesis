versionSelection: aNumber
	aNumber = 0
		ifTrue: [versionInfo _ nil]
		ifFalse: [versionInfo _ self versionInfos at: aNumber].
	self changed: #versionSelection; changed: #versionList