versionSelection: aNumber
	aNumber isZero 
		ifTrue: [ selectedVersion _ version _ nil ]
		ifFalse: [ 
			selectedVersion _ self versionList at: aNumber.
			version _ repository versionFromFileNamed: selectedVersion ].
	self changed: #versionSelection; changed: #summary