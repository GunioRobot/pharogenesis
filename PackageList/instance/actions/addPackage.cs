addPackage
	| packageName |
	packageName _ FillInTheBlank request: 'Package name:'.
	packageName isEmpty ifFalse:
		[selectedPackage _ self packageOrganizer registerPackageNamed: packageName.
		self changed: #packageSelection]