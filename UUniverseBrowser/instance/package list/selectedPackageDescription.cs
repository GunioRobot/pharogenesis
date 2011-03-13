selectedPackageDescription
	self anyPackageSelected ifFalse: [ ^ '' ].
	^ self selectedPackage longDescription 
	