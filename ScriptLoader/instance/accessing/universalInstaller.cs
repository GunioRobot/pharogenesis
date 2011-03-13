universalInstaller
	(Smalltalk at: #UUniverse ifAbsent: [self installingUniverse]).
	^ self installer