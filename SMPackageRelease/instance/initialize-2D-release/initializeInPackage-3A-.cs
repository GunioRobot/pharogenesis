initializeInPackage: aPackage
	"Initialize package release.
	Currently we do not support branching so we simply
	pick the next available version number."

	| previous |
	self map: aPackage map id: UUID new.
	package _ aPackage.
	previous _ package lastRelease.
	automaticVersion _ 	previous ifNil: [VersionNumber first]
							ifNotNil: [previous automaticVersion next].
	version _ note _ downloadUrl _ ''