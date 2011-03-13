createNewPackage
	| package |
	package := UPackage new.
	Utilities authorInitialsPerSe ifNotNil: [
		package maintainer: Utilities authorInitialsPerSe
	].
	^package