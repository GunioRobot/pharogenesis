initializeFromRelease: parentRelease package: aPackage
	"Initialize package release from a given parent.
	Branch if needed."

	self map: aPackage map id: UUID new.
	package := aPackage.
	automaticVersion :=
		parentRelease
			ifNil: [VersionNumber first]
			ifNotNil: [parentRelease nextOrBranch].
	version := note := downloadUrl := ''