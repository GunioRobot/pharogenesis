packageSelection: aNumber
	selectedPackage _ aNumber isZero
		ifFalse: [ self packageList at: aNumber ].
	self versionSelection: 0.
	self changed: #packageSelection; changed: #versionList